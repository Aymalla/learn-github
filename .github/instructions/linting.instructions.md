# Linting & Code Analysis Instructions

This project uses automated linting and code analysis to enforce standards at build time.

## Analyzers Configured

### 1. .NET Roslyn Analyzers (`Microsoft.CodeAnalysis.NetAnalyzers`)
Built-in .NET code quality and reliability rules. Configured via `.editorconfig` and `Directory.Build.props`.

Key rule categories:
- **CA1xxx** — Design rules
- **CA2xxx** — Usage/reliability rules
- **CA3xxx** — Security rules
- **CA5xxx** — Security vulnerability rules

### 2. StyleCop Analyzers (`StyleCop.Analyzers`)
Enforces consistent C# code style. Configured via `stylecop.json`.

Key rule categories:
- **SA1xxx** — Spacing, readability, ordering, naming, documentation, layout

### 3. EditorConfig (`.editorconfig`)
IDE-level formatting enforcement for indentation, line endings, encoding, and C# code style preferences.

## Running Linting Locally

```bash
# Build with analyzers (shows warnings/errors)
dotnet build

# Check code formatting
dotnet format --verify-no-changes

# Auto-fix formatting issues
dotnet format

# Check for specific analyzer violations
dotnet build /p:TreatWarningsAsErrors=true
```

## Suppressing Analyzer Warnings

Only suppress warnings when you have a **valid reason**. Always document why.

### Option 1: Inline suppression (single occurrence)
```csharp
#pragma warning disable CA1062 // Validate arguments of public methods
public void Method(string param) // param is validated by framework
#pragma warning restore CA1062
```

### Option 2: Attribute suppression
```csharp
[SuppressMessage("Design", "CA1062:Validate arguments", Justification = "Validated by ASP.NET model binding")]
public IActionResult Create(Book book)
```

### Option 3: EditorConfig rule (project-wide)
```ini
# In .editorconfig
dotnet_diagnostic.CA1062.severity = none
```

## CI/CD Integration

The `dotnet-ci.yml` workflow runs:
1. `dotnet build` — compiles with all analyzers enabled
2. `dotnet format --verify-no-changes` — checks formatting
3. `dotnet test` — runs all tests

Analyzer violations will cause the build to produce warnings. Enable `TreatWarningsAsErrors` for strict enforcement.

## Common Analyzer Rules

| Rule ID  | Description                          | Action         |
|----------|--------------------------------------|----------------|
| CA1062   | Validate arguments of public methods | Fix: add null checks |
| CA1303   | Do not pass literals as parameters   | Fix: use resources   |
| CA2007   | Do not directly await a Task         | Fix: add ConfigureAwait |
| SA1101   | Prefix local calls with this         | Suppress (optional) |
| SA1200   | Using should be outside namespace    | Already configured   |
| SA1633   | File must have header                | Configured in stylecop.json |
| IDE0055  | Fix formatting                       | Fix: run dotnet format |
