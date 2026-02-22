# Contributing to learn-github

Thank you for your interest in contributing to this project! This document provides guidelines and instructions for contributing.

## Table of Contents
- [Getting Started](#getting-started)
- [Development Workflow](#development-workflow)
- [Coding Standards](#coding-standards)
- [Commit Guidelines](#commit-guidelines)
- [Pull Request Process](#pull-request-process)
- [Testing](#testing)
- [Using GitHub Copilot](#using-github-copilot)

## Getting Started

### Prerequisites
- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Git](https://git-scm.com/)
- A code editor (VS Code, Visual Studio 2022, or JetBrains Rider recommended)
- [GitHub Copilot](https://github.com/features/copilot) (optional but recommended)

### Setting Up Your Development Environment

1. **Fork the repository**
   ```bash
   # Click the 'Fork' button on GitHub
   ```

2. **Clone your fork**
   ```bash
   git clone https://github.com/YOUR-USERNAME/learn-github.git
   cd learn-github
   ```

3. **Add upstream remote**
   ```bash
   git remote add upstream https://github.com/Aymalla/learn-github.git
   ```

4. **Install dependencies**
   ```bash
   dotnet restore
   ```

5. **Build the project**
   ```bash
   dotnet build
   ```

6. **Run the application**
   ```bash
   cd src/web-app
   dotnet run
   ```

## Development Workflow

1. **Create a feature branch**
   ```bash
   git checkout main
   git pull upstream main
   git checkout -b feature/your-feature-name
   ```

2. **Make your changes**
   - Write clean, maintainable code
   - Follow the coding standards
   - Add tests for new functionality
   - Update documentation as needed

3. **Test your changes**
   ```bash
   dotnet test
   ```

4. **Commit your changes**
   ```bash
   git add .
   git commit -m "feat: add descriptive commit message"
   ```

5. **Push to your fork**
   ```bash
   git push origin feature/your-feature-name
   ```

6. **Create a Pull Request**
   - Go to the original repository on GitHub
   - Click "New Pull Request"
   - Select your fork and branch
   - Fill out the PR template completely

## Coding Standards

### C# Code Style
- Follow [Microsoft's C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use **PascalCase** for public members, types, and namespaces
- Use **camelCase** for private fields and local variables
- Prefix private fields with underscore `_fieldName` (optional but consistent if used)
- Use meaningful and descriptive names
- Keep methods small and focused (Single Responsibility Principle)
- Add XML documentation comments for public APIs

### Example
```csharp
/// <summary>
/// Represents a book in the library system.
/// </summary>
public class Book
{
    /// <summary>
    /// Gets or sets the unique identifier for the book.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the title of the book.
    /// </summary>
    [Required]
    [StringLength(200)]
    public string Title { get; set; }
}
```

### File Organization
- **Controllers**: `src/web-app/Controllers/`
- **Models**: `src/web-app/Models/`
- **Views**: `src/web-app/Views/`
- **Tests**: `src/web-app/test/`
- **Static Files**: `src/web-app/wwwroot/`

### HTML/CSS/JavaScript
- Use semantic HTML5 elements
- Follow accessibility best practices (WCAG 2.1)
- Keep CSS organized and use consistent naming
- Use modern JavaScript (ES6+)
- Avoid inline styles and scripts

## Commit Guidelines

We follow the [Conventional Commits](https://www.conventionalcommits.org/) specification:

### Commit Message Format
```
<type>(<scope>): <subject>

<body>

<footer>
```

### Types
- **feat**: A new feature
- **fix**: A bug fix
- **docs**: Documentation only changes
- **style**: Code style changes (formatting, semicolons, etc.)
- **refactor**: Code change that neither fixes a bug nor adds a feature
- **perf**: Performance improvements
- **test**: Adding or updating tests
- **chore**: Maintenance tasks, dependency updates

### Examples
```bash
feat(books): add search functionality to books controller
fix(ui): resolve modal close button alignment issue
docs: update README with setup instructions
test(controllers): add unit tests for BooksController
```

## Pull Request Process

1. **Ensure your PR**:
   - Follows the coding standards
   - Includes relevant tests
   - Updates documentation if needed
   - Has a clear description of changes
   - References related issues

2. **PR Checklist**:
   - [ ] Code builds without errors
   - [ ] All tests pass
   - [ ] No merge conflicts
   - [ ] PR template is filled out
   - [ ] Self-review completed
   - [ ] Documentation updated

3. **Review Process**:
   - Maintainers will review your PR
   - Address any requested changes
   - Keep discussion professional and constructive
   - Be patient - reviews may take time

4. **After Approval**:
   - Maintainers will merge your PR
   - Your contribution will be acknowledged
   - Delete your feature branch

## Testing

### Running Tests
```bash
# Run all tests
dotnet test

# Run tests with coverage
dotnet test /p:CollectCoverage=true

# Run specific test
dotnet test --filter "FullyQualifiedName~BooksControllerTests"
```

### Writing Tests
- Use xUnit framework
- Follow AAA pattern (Arrange, Act, Assert)
- Use descriptive test names
- Test edge cases and error conditions
- Aim for high code coverage (>80%)

### Example Test
```csharp
[Fact]
public void Create_ReturnsViewResult_WhenModelStateIsValid()
{
    // Arrange
    var controller = new BooksController();
    var book = new Book { Title = "Test Book" };
    
    // Act
    var result = controller.Create(book);
    
    // Assert
    Assert.IsType<ViewResult>(result);
}
```

## Using GitHub Copilot

### Best Practices
1. **Write clear comments** describing what you want
   ```csharp
   // Create a method that validates book ISBN format
   ```

2. **Use descriptive names** for better suggestions
   ```csharp
   public bool ValidateBookIsbn(string isbn)
   ```

3. **Leverage context** - Copilot learns from your open files
   - Keep relevant files open in tabs
   - Reference existing patterns

4. **Review suggestions** - Don't blindly accept
   - Ensure code quality
   - Verify logic correctness
   - Check for security issues

### Copilot Instructions
This repository includes custom Copilot instructions in `.github/copilot-instructions.md`. Review this file to understand:
- Project structure and conventions
- Common patterns used in the codebase
- Technology stack details
- Development guidelines

## Questions or Need Help?

- **Issues**: Open an issue for bugs or feature requests
- **Discussions**: Use GitHub Discussions for questions
- **Documentation**: Check the [wiki](../../wiki) for detailed guides

## Code of Conduct

- Be respectful and inclusive
- Provide constructive feedback
- Focus on the code, not the person
- Help create a welcoming environment

## License

By contributing, you agree that your contributions will be licensed under the same license as the project (see LICENSE file).

---

Thank you for contributing! 🎉
