---
applyTo: "**/*.{cs,cshtml,csproj}"
---

# ASP.NET Core MVC Best Practices Instructions

Follow these patterns and practices for all ASP.NET Core MVC development.

## Project Architecture

### Layer Separation

```
Controllers  →  Services  →  Repositories  →  Data
     ↓              ↓              ↓
   Views        Models/DTOs    Entities
```

- **Controllers**: Handle HTTP requests, delegate to services, return views/results
- **Services**: Business logic, validation, orchestration
- **Models**: Data transfer objects, view models, domain entities
- **Views**: Razor templates for rendering HTML

### Controller Best Practices

```csharp
/// <summary>
/// Manages book-related operations.
/// </summary>
public class BooksController : Controller
{
    private readonly IBookService _bookService;
    private readonly ILogger<BooksController> _logger;

    public BooksController(IBookService bookService, ILogger<BooksController> logger)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}
```

**Rules:**

- Controllers should be thin — delegate to services
- Use constructor injection for dependencies
- Always validate `ModelState.IsValid` before processing POST/PUT
- Use `nameof()` for action references: `RedirectToAction(nameof(Index))`
- Return appropriate status codes and result types
- Use `[HttpGet]`, `[HttpPost]`, `[HttpPut]`, `[HttpDelete]` explicitly
- Apply `[ValidateAntiForgeryToken]` to all state-changing actions
- Use `[Bind]` to prevent over-posting

### Model/ViewModel Patterns

```csharp
// Domain Model — represents the data entity
public class Book
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, MinimumLength = 1)]
    [Display(Name = "Book Title")]
    public string Title { get; set; } = string.Empty;
}

// ViewModel — shapes data for a specific view
public class BookListViewModel
{
    public IReadOnlyList<Book> Books { get; init; } = [];
    public string? SearchTerm { get; init; }
    public int TotalCount { get; init; }
    public int CurrentPage { get; init; } = 1;
}
```

**Rules:**

- Use Data Annotations for validation
- Use `Display` attribute for label text
- Initialize properties with defaults (avoid null)
- Use ViewModels for complex views
- Keep models focused — one responsibility per class

### View Best Practices

```cshtml
@model BookListViewModel

@* Use Tag Helpers — not HTML Helpers *@
<form asp-action="Create" asp-controller="Books" method="post">
    @Html.AntiForgeryToken()

    <div class="form-group">
        <label asp-for="Title"></label>
        <input asp-for="Title" class="form-control" />
        <span asp-validation-for="Title" class="text-danger"></span>
    </div>

    <button type="submit" class="btn btn-primary">Save</button>
</form>
```

**Rules:**

- Always declare `@model` at the top of views
- Use Tag Helpers (`asp-for`, `asp-action`, `asp-controller`)
- Use `asp-validation-for` for field-level validation messages
- Use `asp-validation-summary` for model-level errors
- Keep views simple — no business logic
- Use partial views (`_PartialName.cshtml`) for reusable components
- Use `_ViewImports.cshtml` for shared directives
- Use `_ViewStart.cshtml` for shared layout configuration

## Dependency Injection

```csharp
// Program.cs — register services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
builder.Services.AddTransient<IEmailService, EmailService>();
```

**Lifetime Rules:**
| Lifetime | Use When |
|-------------|---------------------------------------------|
| `Singleton` | Stateless services, caches, configuration |
| `Scoped` | Per-request services, DB contexts, repos |
| `Transient` | Lightweight, stateless, short-lived services|

**Rules:**

- Program to interfaces, not implementations
- Use constructor injection — never `HttpContext.RequestServices`
- Register all dependencies in `Program.cs`
- Avoid the Service Locator anti-pattern

## Middleware Pipeline

Order matters in `Program.cs`:

```csharp
app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();    // before Authorization
app.UseAuthorization();
app.MapControllerRoute(...);
```

## Logging

```csharp
// Use structured logging with ILogger<T>
_logger.LogInformation("Book created: {BookId} - {Title}", book.Id, book.Title);
_logger.LogWarning("Book not found: {BookId}", id);
_logger.LogError(ex, "Failed to create book: {Title}", book.Title);
```

**Rules:**

- Use `ILogger<T>` — never `Console.WriteLine()`
- Use structured logging with named placeholders `{Name}`
- Use appropriate log levels (Trace, Debug, Information, Warning, Error, Critical)
- Never log sensitive data (passwords, tokens, PII)

## Configuration

- Use `appsettings.json` and `appsettings.{Environment}.json`
- Use Options pattern for strongly-typed configuration
- Use User Secrets for development secrets
- Use environment variables for production secrets
- Never commit secrets to source control
