---
applyTo: "**/*.{cs,cshtml,js,css}"
---

# Coding Standards Instructions

These are the mandatory coding standards for this repository. All code contributions MUST follow these rules.

## C# Coding Standards

### Naming Conventions

| Element            | Convention     | Example                         |
| ------------------ | -------------- | ------------------------------- |
| Namespace          | PascalCase     | `LibraryManagementWebApp`       |
| Class              | PascalCase     | `BooksController`               |
| Interface          | I + PascalCase | `IBookService`                  |
| Method             | PascalCase     | `GetBookById()`                 |
| Property           | PascalCase     | `Title`, `IsAvailable`          |
| Public field       | PascalCase     | `MaxRetries`                    |
| Private field      | \_camelCase    | `_logger`, `_bookService`       |
| Parameter          | camelCase      | `bookId`, `searchTerm`          |
| Local variable     | camelCase      | `existingBook`, `isValid`       |
| Constant           | PascalCase     | `MaxPageSize`, `DefaultTimeout` |
| Enum               | PascalCase     | `BookStatus.Available`          |
| Generic type param | T + PascalCase | `TEntity`, `TResult`            |

### File Organization

Every C# file MUST follow this order:

1. `using` directives (System first, then third-party, then project)
2. Namespace declaration (file-scoped preferred: `namespace X;`)
3. Class/interface declaration
4. Members in this order:
   - Constants
   - Static fields
   - Instance fields (private)
   - Constructors
   - Public properties
   - Public methods
   - Private methods

### Code Rules

- **One class per file** — file name must match class name
- **Braces on new lines** (Allman style)
- **Always use braces** for `if`, `else`, `for`, `foreach`, `while`, even for single-line bodies
- **Max line length**: 120 characters
- **Max method length**: 30 lines (excluding comments/whitespace)
- **Max parameters**: 5 per method; use an options/request object for more
- **No magic numbers** — use named constants or enums
- **No `var`** for non-obvious types; use explicit types when the type isn't clear from the right side
- **Use `var`** when the type is obvious from `new`, cast, or factory method
- **Use string interpolation** over `string.Format()` or concatenation
- **Use `nameof()`** instead of hardcoded strings for member references
- **Always use `readonly`** for fields that don't change after construction

### Null Safety

- Enable nullable reference types (`<Nullable>enable</Nullable>` in .csproj)
- Use null-conditional operators (`?.`, `??`) over explicit null checks where appropriate
- Never return `null` from collections — return empty collections instead
- Use `[Required]` data annotations for mandatory model properties
- Use `string.Empty` instead of `""`

### Async/Await

- Suffix async methods with `Async` (e.g., `GetBooksAsync()`)
- Always use `async/await` — never use `.Result` or `.Wait()`
- Use `CancellationToken` for long-running operations
- Prefer `ValueTask` over `Task` for hot paths that often complete synchronously
- Always `await` or return the Task — never fire-and-forget without explicit intent

### Exception Handling

- Catch specific exceptions, never bare `catch` or `catch (Exception)`
- Use `try-catch` only when you can meaningfully handle the error
- Log exceptions with structured logging: `_logger.LogError(ex, "message {Param}", param)`
- Throw `ArgumentNullException` for null arguments using `ArgumentNullException.ThrowIfNull()`
- Never swallow exceptions silently
- Use Problem Details (RFC 7807) for API error responses

### XML Documentation

Add XML documentation to ALL public members:

```csharp
/// <summary>
/// Retrieves a book by its unique identifier.
/// </summary>
/// <param name="id">The unique identifier of the book.</param>
/// <returns>The book if found; otherwise, null.</returns>
/// <exception cref="ArgumentNullException">Thrown when id is null or empty.</exception>
public Book? GetBookById(string id)
```

## Razor View Standards

- Use Tag Helpers over HTML Helpers
- Always include `asp-antiforgery="true"` on forms (or `[ValidateAntiForgeryToken]` on POST actions)
- Use `asp-for` and `asp-validation-for` Tag Helpers for model binding
- Keep views simple — move logic to ViewModels or controllers
- Use partial views for reusable UI components
- Always escape user input (Razor does this by default — never use `@Html.Raw()` with user data)

## JavaScript Standards

- Use ES6+ syntax (`const`/`let`, arrow functions, template literals)
- No `var` — use `const` by default, `let` only when reassignment is needed
- Use strict mode (`'use strict';` or module scope)
- Place scripts in `wwwroot/js/` — never inline in views
- Use `addEventListener` — never inline event handlers (`onclick`, etc.)
- Handle errors in async code with try/catch

## CSS Standards

- Use CSS custom properties (variables) for theming
- Follow BEM naming: `.block__element--modifier`
- Mobile-first responsive design
- Place styles in `wwwroot/css/`
- No inline styles in HTML
- Use `rem`/`em` over `px` for sizing
