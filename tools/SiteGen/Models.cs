namespace SiteGen;

/// <summary>A single solution method extracted from the C# source.</summary>
public record SolutionCode(string MethodName, int? Leetcode, string Code, string Summary);

/// <summary>Metadata for one problem, loaded from content/problems/&lt;slug&gt;/meta.json.</summary>
public class ProblemMeta
{
    public int? Leetcode { get; set; }
    public string? LeetcodeSlug { get; set; }
    public string Difficulty { get; set; } = "";
    public List<string> Tags { get; set; } = new();
    public string SourceFile { get; set; } = "";
    public List<string> Methods { get; set; } = new();
    public Dictionary<string, string> Titles { get; set; } = new();
    public int Order { get; set; }
}

/// <summary>A fully assembled problem ready to render (metadata + code + per-language description).</summary>
public class Problem
{
    public required string Slug { get; init; }
    public required ProblemMeta Meta { get; init; }
    public required string TopicKey { get; init; }
    public List<SolutionCode> Codes { get; init; } = new();
    public Dictionary<string, string> DescriptionHtml { get; init; } = new();

    public string Title(string lang) =>
        Meta.Titles.TryGetValue(lang, out var t) && !string.IsNullOrWhiteSpace(t)
            ? t
            : Meta.Titles.GetValueOrDefault("en", Slug);

    public string LeetcodeUrl =>
        Meta.LeetcodeSlug is { Length: > 0 } s ? $"https://leetcode.com/problems/{s}/" : "";
}

/// <summary>Per-language UI configuration.</summary>
public class LangConfig
{
    public required string Code { get; init; }          // "en" / "fa"
    public required string Dir { get; init; }           // "ltr" / "rtl"
    public required string NativeName { get; init; }    // shown in language switcher
    public required Dictionary<string, string> Strings { get; init; }
    public required Dictionary<string, string> Topics { get; init; } // topicKey -> display name

    public string S(string key) => Strings.GetValueOrDefault(key, key);
    public string Topic(string key) => Topics.GetValueOrDefault(key, key);
}
