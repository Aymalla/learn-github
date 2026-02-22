# Testing Standards Instructions

All code changes MUST include appropriate tests. Follow these standards strictly.

## Testing Framework

- **Unit Tests**: xUnit with MSTest adapter
- **Assertions**: Use xUnit `Assert` class
- **Mocking**: Use Moq or NSubstitute for dependency mocking
- **Coverage**: Aim for minimum 80% code coverage on new code

## Test Organization

### File Structure
```
src/web-app/test/
├── Controllers/          # Controller unit tests
├── Models/               # Model validation tests
├── Services/             # Service layer tests
├── Integration/          # Integration tests
└── Helpers/              # Test utilities and shared fixtures
```

### Test File Naming
- Test file: `{ClassName}Tests.cs`
- Example: `BooksControllerTests.cs`, `BookTests.cs`

### Test Class Naming
- `{ClassName}Tests` for flat tests
- `{ClassName}_{MethodName}Tests` for nested/grouped tests

## Test Method Naming

Use this pattern: `MethodName_StateUnderTest_ExpectedBehavior`

```csharp
// GOOD
[Fact]
public void Create_WithValidBook_RedirectsToIndex()

[Fact]
public void Create_WithInvalidModel_ReturnsViewWithErrors()

[Fact]
public void Delete_WithNonExistentId_ReturnsNotFound()

[Fact]
public void Edit_WithNullId_ThrowsArgumentNullException()

// BAD
[Fact]
public void TestCreate()

[Fact]
public void CreateBookTest()
```

## Test Structure (AAA Pattern)

Every test MUST follow Arrange-Act-Assert:

```csharp
[Fact]
public void Create_WithValidBook_AddsBookToList()
{
    // Arrange
    var logger = new Mock<ILogger<BooksController>>();
    var controller = new BooksController(logger.Object);
    var book = new Book
    {
        Title = "Clean Code",
        Author = "Robert C. Martin",
        ISBN = "9780132350884"
    };

    // Act
    var result = controller.Create(book);

    // Assert
    var redirectResult = Assert.IsType<RedirectToActionResult>(result);
    Assert.Equal("Index", redirectResult.ActionName);
}
```

## What to Test

### Controllers
- Each action method returns the correct `IActionResult` type
- Model validation errors return the view with the model
- Valid input redirects correctly
- Edge cases (null parameters, empty collections, not found)
- Proper logging calls are made

### Models
- Required fields are validated
- String length constraints are enforced
- Custom validation logic works
- Default values are correct

### Services (when added)
- Business logic produces correct results
- Error cases are handled
- Dependencies are properly called
- Edge cases are covered

## Test Categories

Use `[Trait]` to categorize tests:

```csharp
[Fact]
[Trait("Category", "Unit")]
public void Create_WithValidBook_Succeeds() { }

[Fact]
[Trait("Category", "Integration")]
public void CreateBook_PersistsToDatabase() { }
```

## Test Data

- Use meaningful test data — not "test1", "abc", "123"
- Create helper methods or builders for complex test objects:

```csharp
private static Book CreateValidBook(string? title = null) => new()
{
    Id = Guid.NewGuid().ToString(),
    Title = title ?? "The Pragmatic Programmer",
    Author = "David Thomas",
    ISBN = "9780135957059",
    IsAvailable = true
};
```

## Do NOT

- Skip writing tests for "simple" code
- Use `Thread.Sleep()` in tests — use async/await properly
- Share mutable state between tests
- Write tests that depend on execution order
- Ignore flaky tests — fix them immediately
- Test framework internals (ASP.NET Core, EF Core, etc.)
- Write tests that require external services (database, API) without mocking
