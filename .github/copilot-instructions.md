# GitHub Copilot Instructions for learn-github

## Project Overview
This is a .NET 9.0 ASP.NET Core MVC web application for managing books. The project demonstrates GitHub workflows, CI/CD practices, and modern web development patterns.

## Technology Stack
- **Framework**: ASP.NET Core 9.0 MVC
- **Language**: C# 12
- **Testing**: xUnit (for controller tests)
- **Frontend**: Razor Views, HTML5, CSS3, JavaScript
- **Build**: dotnet CLI

## Code Style & Conventions

### C# Conventions
- Use **PascalCase** for class names, method names, and properties
- Use **camelCase** for local variables and parameters
- Use **async/await** for asynchronous operations
- Follow [Microsoft C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use nullable reference types where appropriate
- Add XML documentation comments for public APIs

### Project Structure
```
src/web-app/
├── Controllers/     # MVC Controllers
├── Models/          # Data models and ViewModels
├── Views/           # Razor views
├── wwwroot/         # Static files (CSS, JS, images)
└── test/            # Unit and integration tests
```

## Development Guidelines

### When Creating Controllers
- Inherit from `Controller` base class
- Use attribute routing when appropriate
- Return appropriate `IActionResult` types
- Add proper error handling and validation
- Include unit tests in `test/Controllers/`

### When Creating Models
- Place in `Models/` directory
- Use data annotations for validation
- Implement `IEquatable<T>` for value comparison when needed
- Keep models simple and focused

### When Creating Views
- Use Razor syntax consistently
- Follow the established layout structure (`_Layout.cshtml`)
- Include proper HTML5 semantic elements
- Ensure accessibility (ARIA labels, alt text)
- Keep JavaScript in separate files under `wwwroot/js/`

### Testing
- Write unit tests for all controller actions
- Use descriptive test method names (e.g., `Create_ReturnsViewResult_WhenModelStateIsValid`)
- Follow AAA pattern (Arrange, Act, Assert)
- Mock dependencies appropriately

## Common Patterns

### Controller Action Pattern
```csharp
[HttpGet]
public IActionResult ActionName()
{
    // Implementation
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> ActionName(Model model)
{
    if (!ModelState.IsValid)
    {
        return View(model);
    }
    
    // Process
    return RedirectToAction(nameof(Index));
}
```

### Error Handling
- Use try-catch blocks for expected exceptions
- Log errors appropriately
- Return user-friendly error messages
- Use Problem Details for API endpoints

## GitHub Copilot Tips
- Be specific in comments about what you need
- Reference existing patterns in the codebase
- Use descriptive variable and method names
- Copilot learns from the current file context

## Resources
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [C# Language Reference](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [xUnit Documentation](https://xunit.net/)
