# MrAlgorithmsPractice

Annotated C# solutions to LeetCode top interview questions, with a bilingual
(English / فارسی) static website generated straight from the source code.

## Website

The site is generated from the C# sources plus authored descriptions and published to
GitHub Pages: **https://boumipour.github.io/MrAlgorithmsPractice/**

- **Code** is pulled directly from `src/**/*.cs` (single source of truth).
- **Explanations** are authored per problem under `content/problems/<slug>/` in `en.md` and
  `fa.md`, with metadata in `meta.json`.
- **UI strings / topic names** live in `content/ui/en.json` and `content/ui/fa.json`.

### Build the site locally

```bash
dotnet run --project tools/SiteGen      # writes the site to dist/
# then open dist/index.html in a browser
```

### Deployment

`.github/workflows/deploy-site.yml` regenerates and deploys the site on every push to `main`.
**One-time setup:** in the repo, go to **Settings → Pages → Build and deployment → Source** and
select **GitHub Actions**.

### Add a new problem to the site

1. Add the solution method in `src/...` following the `Name_<LeetCodeNumber>` convention.
2. Create `content/problems/<number>-<slug>/` with:
   - `meta.json` — `leetcode`, `leetcodeSlug`, `difficulty`, `tags`, `sourceFile`, `methods`,
     and bilingual `titles`.
   - `en.md` and `fa.md` — the explanations (missing files fall back to the XML `<summary>`).

## Solutions project

Plain .NET 10 console app (`Algoritms.csproj`);

```bash
dotnet build      # build the solutions project
dotnet run        # run Program.cs
```
