using System.Text.Json;
using Markdig;

namespace SiteGen;

/// <summary>Loads authored content (problem metadata, Markdown descriptions, UI language configs).</summary>
public class ContentLoader
{
    private static readonly JsonSerializerOptions JsonOpts = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
    };

    private static readonly MarkdownPipeline Markdown =
        new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();

    private readonly string _repoRoot;
    private readonly string _contentDir;

    public ContentLoader(string repoRoot)
    {
        _repoRoot = repoRoot;
        _contentDir = Path.Combine(repoRoot, "content");
    }

    public List<LangConfig> LoadLanguages()
    {
        var dir = Path.Combine(_contentDir, "ui");
        var langs = new List<LangConfig>();

        foreach (var file in Directory.EnumerateFiles(dir, "*.json").OrderBy(f => f))
        {
            var dto = JsonSerializer.Deserialize<LangDto>(File.ReadAllText(file), JsonOpts)
                      ?? throw new InvalidDataException($"Could not parse {file}");
            langs.Add(new LangConfig
            {
                Code = dto.Code,
                Dir = dto.Dir,
                NativeName = dto.NativeName,
                Strings = dto.Strings,
                Topics = dto.Topics,
            });
        }

        if (langs.Count == 0)
            throw new InvalidDataException($"No language configs found under {dir}");

        return langs;
    }

    public List<Problem> LoadProblems(CodeExtractor extractor, IReadOnlyCollection<string> langCodes)
    {
        var problemsDir = Path.Combine(_contentDir, "problems");
        var problems = new List<Problem>();

        foreach (var dir in Directory.EnumerateDirectories(problemsDir))
        {
            var slug = Path.GetFileName(dir);
            var metaPath = Path.Combine(dir, "meta.json");
            if (!File.Exists(metaPath))
            {
                Console.WriteLine($"  ! skipping {slug}: no meta.json");
                continue;
            }

            var meta = JsonSerializer.Deserialize<ProblemMeta>(File.ReadAllText(metaPath), JsonOpts)
                       ?? throw new InvalidDataException($"Could not parse {metaPath}");

            var codes = ResolveCodes(extractor, meta);
            var fallbackSummary = codes.FirstOrDefault()?.Summary ?? "";

            var descriptions = new Dictionary<string, string>();
            foreach (var lang in langCodes)
            {
                var mdPath = Path.Combine(dir, $"{lang}.md");
                descriptions[lang] = File.Exists(mdPath)
                    ? Markdig.Markdown.ToHtml(File.ReadAllText(mdPath), Markdown)
                    : $"<p>{System.Net.WebUtility.HtmlEncode(fallbackSummary)}</p>";
            }

            problems.Add(new Problem
            {
                Slug = slug,
                Meta = meta,
                TopicKey = TopicKeyFromSource(meta.SourceFile),
                Codes = codes,
                DescriptionHtml = descriptions,
            });
        }

        return problems
            .OrderBy(p => p.TopicKey)
            .ThenBy(p => p.Meta.Order)
            .ThenBy(p => p.Meta.Leetcode ?? int.MaxValue)
            .ToList();
    }

    private List<SolutionCode> ResolveCodes(CodeExtractor extractor, ProblemMeta meta)
    {
        if (meta.Methods.Count > 0)
        {
            var list = new List<SolutionCode>();
            foreach (var name in meta.Methods)
            {
                if (extractor.Methods.TryGetValue(name, out var code))
                    list.Add(code);
                else
                    Console.WriteLine($"  ! method '{name}' not found in sources");
            }
            return list;
        }

        // No methods listed: render the whole type (e.g. a data structure class).
        if (!string.IsNullOrWhiteSpace(meta.SourceFile))
        {
            var abs = Path.Combine(_repoRoot, meta.SourceFile.Replace('/', Path.DirectorySeparatorChar));
            if (File.Exists(abs))
                return new List<SolutionCode> { new("", meta.Leetcode, CodeExtractor.CleanTypesFromFile(abs), "") };
        }

        return new List<SolutionCode>();
    }

    private static string TopicKeyFromSource(string sourceFile)
    {
        var parts = sourceFile.Replace('\\', '/').Split('/', StringSplitOptions.RemoveEmptyEntries);
        var srcIdx = Array.IndexOf(parts, "src");
        return srcIdx >= 0 && srcIdx + 1 < parts.Length ? parts[srcIdx + 1] : "Other";
    }

    private class LangDto
    {
        public string Code { get; set; } = "";
        public string Dir { get; set; } = "ltr";
        public string NativeName { get; set; } = "";
        public Dictionary<string, string> Strings { get; set; } = new();
        public Dictionary<string, string> Topics { get; set; } = new();
    }
}
