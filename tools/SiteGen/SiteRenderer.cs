using System.Net;
using System.Text;

namespace SiteGen;

/// <summary>Renders the assembled problems into a static, per-language HTML site.</summary>
public class SiteRenderer
{
    private readonly string _templatesDir;
    private readonly string _outDir;
    private readonly string _layout;

    public SiteRenderer(string templatesDir, string outDir)
    {
        _templatesDir = templatesDir;
        _outDir = outDir;
        _layout = File.ReadAllText(Path.Combine(templatesDir, "layout.html"));
    }

    public void Render(List<LangConfig> langs, List<Problem> problems)
    {
        if (Directory.Exists(_outDir)) Directory.Delete(_outDir, recursive: true);
        Directory.CreateDirectory(_outDir);

        CopyAssets();

        foreach (var lang in langs)
        {
            var langDir = Path.Combine(_outDir, lang.Code);
            Directory.CreateDirectory(langDir);

            File.WriteAllText(Path.Combine(langDir, "index.html"),
                Page(lang, langs, "index.html", lang.S("siteTitle"), BuildIndex(lang, problems)));

            foreach (var p in problems)
                File.WriteAllText(Path.Combine(langDir, $"{p.Slug}.html"),
                    Page(lang, langs, $"{p.Slug}.html", $"{p.Title(lang.Code)} · {lang.S("siteTitle")}",
                         BuildProblem(lang, p)));
        }

        WriteRootRedirect(langs);
    }

    // ---- page bodies ---------------------------------------------------------

    private static string BuildIndex(LangConfig lang, List<Problem> problems)
    {
        var sb = new StringBuilder();
        sb.Append($"<section class=\"intro\"><h1>{Enc(lang.S("siteTitle"))}</h1>")
          .Append($"<p>{Enc(lang.S("tagline"))}</p></section>");

        foreach (var group in problems.GroupBy(p => p.TopicKey))
        {
            sb.Append($"<section class=\"topic-group\"><h2 class=\"topic\">{Enc(lang.Topic(group.Key))}</h2><ul class=\"problem-list\">");
            foreach (var p in group)
            {
                var num = p.Meta.Leetcode?.ToString() ?? "•";
                sb.Append($"<li><a href=\"./{p.Slug}.html\">")
                  .Append($"<span class=\"num\">{Enc(num)}</span>")
                  .Append($"<span class=\"ptitle\">{Enc(p.Title(lang.Code))}</span>")
                  .Append(DiffBadge(lang, p.Meta.Difficulty))
                  .Append("</a></li>");
            }
            sb.Append("</ul></section>");
        }
        return sb.ToString();
    }

    private static string BuildProblem(LangConfig lang, Problem p)
    {
        var sb = new StringBuilder();
        sb.Append("<article class=\"problem\">");
        sb.Append($"<div class=\"crumbs\"><a href=\"./index.html\">{Enc(lang.S("home"))}</a> / <span>{Enc(lang.Topic(p.TopicKey))}</span></div>");

        var heading = p.Meta.Leetcode is int n ? $"{n}. {p.Title(lang.Code)}" : p.Title(lang.Code);
        sb.Append($"<h1>{Enc(heading)}</h1>");

        sb.Append("<div class=\"meta-row\">");
        sb.Append(DiffBadge(lang, p.Meta.Difficulty));
        foreach (var tag in p.Meta.Tags)
            sb.Append($"<span class=\"chip\">{Enc(tag)}</span>");
        if (p.LeetcodeUrl.Length > 0)
            sb.Append($"<a class=\"lc-link\" href=\"{Enc(p.LeetcodeUrl)}\" target=\"_blank\" rel=\"noopener\">{Enc(lang.S("viewOnLeetcode"))} ↗</a>");
        sb.Append("</div>");

        sb.Append($"<section class=\"description\">{p.DescriptionHtml.GetValueOrDefault(lang.Code, "")}</section>");

        sb.Append($"<h2 class=\"solution-title\">{Enc(lang.S("solution"))}</h2>");
        foreach (var code in p.Codes)
        {
            sb.Append("<div class=\"code-block\">");
            sb.Append($"<button class=\"copy-btn\" type=\"button\" data-copy>{Enc(lang.S("copy"))}</button>");
            sb.Append($"<pre><code class=\"language-csharp\">{Enc(code.Code)}</code></pre>");
            sb.Append("</div>");
        }
        sb.Append("</article>");
        return sb.ToString();
    }

    private static string DiffBadge(LangConfig lang, string difficulty)
    {
        if (string.IsNullOrWhiteSpace(difficulty)) return "";
        var label = lang.S($"diff_{difficulty}");
        return $"<span class=\"diff diff-{difficulty.ToLowerInvariant()}\">{Enc(label)}</span>";
    }

    // ---- layout / assets -----------------------------------------------------

    private string Page(LangConfig lang, List<LangConfig> all, string fileName, string title, string body)
    {
        var rtlCss = lang.Dir == "rtl"
            ? "<link rel=\"stylesheet\" href=\"../assets/style-rtl.css\">"
            : "";
        var font = lang.Dir == "rtl"
            ? "<link rel=\"preconnect\" href=\"https://cdn.jsdelivr.net\"><link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/gh/rastikerdar/vazirmatn@v33.003/Vazirmatn-font-face.css\">"
            : "";

        var switcher = new StringBuilder();
        foreach (var other in all)
        {
            if (other.Code == lang.Code)
                switcher.Append($"<span class=\"lang current\">{Enc(other.NativeName)}</span>");
            else
                switcher.Append($"<a class=\"lang\" href=\"../{other.Code}/{fileName}\">{Enc(other.NativeName)}</a>");
        }

        return _layout
            .Replace("{{LANG}}", lang.Code)
            .Replace("{{DIR}}", lang.Dir)
            .Replace("{{TITLE}}", Enc(title))
            .Replace("{{RTL_CSS}}", rtlCss)
            .Replace("{{FONT}}", font)
            .Replace("{{SITE_TITLE}}", Enc(lang.S("siteTitle")))
            .Replace("{{LANG_SWITCH}}", switcher.ToString())
            .Replace("{{FOOTER}}", Enc(lang.S("footer")))
            .Replace("{{BODY}}", body);
    }

    private void CopyAssets()
    {
        var assetsOut = Path.Combine(_outDir, "assets");
        Directory.CreateDirectory(assetsOut);
        foreach (var name in new[] { "style.css", "style-rtl.css", "app.js" })
        {
            var src = Path.Combine(_templatesDir, name);
            if (File.Exists(src)) File.Copy(src, Path.Combine(assetsOut, name), overwrite: true);
        }
    }

    private void WriteRootRedirect(List<LangConfig> langs)
    {
        var def = langs.Any(l => l.Code == "en") ? "en" : langs[0].Code;
        var known = string.Join(",", langs.Select(l => $"'{l.Code}'"));
        var html = $$"""
            <!DOCTYPE html>
            <html lang="{{def}}">
            <head>
            <meta charset="utf-8">
            <title>Algorithms Practice</title>
            <script>
              var known = [{{known}}];
              var pref = (navigator.language || 'en').slice(0, 2);
              var lang = known.indexOf(pref) >= 0 ? pref : '{{def}}';
              location.replace('./' + lang + '/');
            </script>
            <noscript><meta http-equiv="refresh" content="0; url=./{{def}}/"></noscript>
            </head>
            <body></body>
            </html>
            """;
        File.WriteAllText(Path.Combine(_outDir, "index.html"), html);
    }

    private static string Enc(string s) => WebUtility.HtmlEncode(s);
}
