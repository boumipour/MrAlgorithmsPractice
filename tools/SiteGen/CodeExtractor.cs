using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SiteGen;

/// <summary>
/// Reads the C# solution sources with Roslyn and exposes each public method's cleaned code
/// and XML summary, keyed by method name.
/// </summary>
public class CodeExtractor
{
    private static readonly Regex LeetcodeInName = new(@"_(\d+)", RegexOptions.Compiled);

    public Dictionary<string, SolutionCode> Methods { get; } = new();

    public CodeExtractor(string srcDir)
    {
        foreach (var file in Directory.EnumerateFiles(srcDir, "*.cs", SearchOption.AllDirectories))
        {
            var root = CSharpSyntaxTree.ParseText(File.ReadAllText(file)).GetRoot();

            foreach (var method in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
            {
                if (!method.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword)))
                    continue;

                var name = method.Identifier.Text;
                var leetcode = ParseLeetcode(name);
                var code = Clean(method.ToFullString());
                var summary = ExtractSummary(method.GetLeadingTrivia().ToFullString());

                Methods[name] = new SolutionCode(name, leetcode, code, summary);
            }
        }
    }

    /// <summary>Returns the cleaned source of every type declared in a file (used for plain data structures).</summary>
    public static string CleanTypesFromFile(string absPath)
    {
        var root = CSharpSyntaxTree.ParseText(File.ReadAllText(absPath)).GetRoot();
        var types = root.DescendantNodes().OfType<TypeDeclarationSyntax>()
            .Where(t => t.Parent is not TypeDeclarationSyntax) // top-level types only
            .Select(t => Clean(t.ToFullString()));
        return string.Join("\n\n", types);
    }

    private static int? ParseLeetcode(string methodName)
    {
        var matches = LeetcodeInName.Matches(methodName);
        return matches.Count > 0 ? int.Parse(matches[^1].Groups[1].Value) : null;
    }

    /// <summary>Strips XML doc comments, trims blank edges, and removes common indentation.</summary>
    private static string Clean(string raw)
    {
        var lines = raw.Replace("\r\n", "\n").Split('\n')
            .Where(l => !l.TrimStart().StartsWith("///"))
            .ToList();

        while (lines.Count > 0 && lines[0].Trim().Length == 0) lines.RemoveAt(0);
        while (lines.Count > 0 && lines[^1].Trim().Length == 0) lines.RemoveAt(lines.Count - 1);

        var indent = lines.Where(l => l.Trim().Length > 0)
            .Select(l => l.Length - l.TrimStart().Length)
            .DefaultIfEmpty(0)
            .Min();

        if (indent > 0)
            lines = lines.Select(l => l.Length >= indent ? l[indent..] : l).ToList();

        return string.Join("\n", lines);
    }

    private static string ExtractSummary(string docTrivia)
    {
        var text = string.Join("\n", docTrivia.Replace("\r\n", "\n").Split('\n')
            .Select(l => l.TrimStart())
            .Where(l => l.StartsWith("///"))
            .Select(l => l[3..].Trim()));

        var match = Regex.Match(text, @"<summary>(.*?)</summary>", RegexOptions.Singleline);
        var summary = match.Success ? match.Groups[1].Value : text;

        summary = Regex.Replace(summary, @"<[^>]+>", " ");       // drop any stray tags
        summary = Regex.Replace(summary, @"\s+", " ").Trim();    // collapse whitespace
        return summary;
    }
}
