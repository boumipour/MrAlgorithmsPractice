using SiteGen;

// Resolve the repository root (override with: dotnet run --project tools/SiteGen -- <repoRoot>).
var repoRoot = args.Length > 0 ? Path.GetFullPath(args[0]) : FindRepoRoot();

var srcDir = Path.Combine(repoRoot, "src");
var templatesDir = Path.Combine(repoRoot, "tools", "SiteGen", "templates");
var outDir = Path.Combine(repoRoot, "dist");

Console.WriteLine($"Repo root : {repoRoot}");
Console.WriteLine($"Sources   : {srcDir}");
Console.WriteLine($"Output    : {outDir}");

var extractor = new CodeExtractor(srcDir);
Console.WriteLine($"Extracted {extractor.Methods.Count} public method(s).");

var content = new ContentLoader(repoRoot);
var langs = content.LoadLanguages();
Console.WriteLine($"Languages : {string.Join(", ", langs.Select(l => l.Code))}");

var problems = content.LoadProblems(extractor, langs.Select(l => l.Code).ToList());
Console.WriteLine($"Problems  : {problems.Count}");

new SiteRenderer(templatesDir, outDir).Render(langs, problems);

Console.WriteLine("Done. Open dist/index.html");

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir is not null)
    {
        if (File.Exists(Path.Combine(dir.FullName, "Algoritms.csproj")) ||
            Directory.Exists(Path.Combine(dir.FullName, ".git")))
            return dir.FullName;
        dir = dir.Parent;
    }
    throw new InvalidOperationException("Could not locate repository root (no Algoritms.csproj / .git found).");
}
