# GitHub Copilot Best Practices for This Repository

This document outlines best practices for using GitHub Copilot effectively within this project.

## Quick Start with Copilot

### 1. Familiarize Yourself with Project Context
Before starting, ensure Copilot has the right context:
- Open [.github/copilot-instructions.md](.github/copilot-instructions.md) to review project conventions
- Keep relevant files open in your editor tabs
- Review existing code patterns in the codebase

### 2. Enable Copilot Features
- **Copilot Suggestions**: Auto-complete as you type
- **Copilot Chat**: Ask questions about the code
- **Copilot Workspace**: Get project-wide assistance

## Effective Prompting

### Writing Good Comments for Copilot

✅ **Good:**
```csharp
// Create a method that validates ISBN-13 format with checksum verification
// Returns true if valid, false otherwise
```

❌ **Bad:**
```csharp
// Validate ISBN
```

### Using Inline Chat

In VS Code, use `Ctrl+I` (Windows/Linux) or `Cmd+I` (Mac):

```
Create a controller action that:
1. Accepts a Book model from POST request
2. Validates the model using data annotations
3. Saves to an in-memory list
4. Returns RedirectToAction on success
5. Returns View with errors on failure
```

## Common Copilot Workflows

### 1. Creating a New Controller

```csharp
// Create a complete REST API controller for Author model
// Include CRUD operations: Index, Details, Create, Edit, Delete
// Follow the pattern used in BooksController
// Add proper validation and error handling
```

### 2. Writing Unit Tests

```csharp
// Generate xUnit tests for BooksController.Create method
// Test cases:
// 1. Valid model returns RedirectToAction
// 2. Invalid model returns View with errors
// 3. Null model throws ArgumentNullException
```

### 3. Adding Data Validation

```csharp
// Add validation attributes to Book model:
// - Title: Required, max length 200
// - Author: Required, max length 100
// - ISBN: Required, matches ISBN-13 format
// - PublishedDate: Not in future
// - Price: Range 0 to 10000
```

### 4. Refactoring Code

Select code and use Copilot Chat:
```
/fix improve this method's performance and readability
```

## Copilot Chat Commands

Use these in Copilot Chat for specific tasks:

| Command | Purpose | Example |
|---------|---------|---------|
| `/explain` | Understand code | `/explain this controller action` |
| `/fix` | Fix issues | `/fix this validation logic` |
| `/tests` | Generate tests | `/tests for UserService` |
| `/doc` | Generate docs | `/doc this public method` |
| `/optimize` | Improve performance | `/optimize this database query` |

## Project-Specific Patterns

### Controller Actions

When creating controller actions, Copilot should follow this pattern:

```csharp
/// <summary>
/// Displays the book creation form.
/// </summary>
/// <returns>View for creating a new book.</returns>
[HttpGet]
public IActionResult Create()
{
    return View();
}

/// <summary>
/// Processes the book creation request.
/// </summary>
/// <param name="book">The book to create.</param>
/// <returns>Redirects to Index on success, returns View on failure.</returns>
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Title,Author,ISBN")] Book book)
{
    if (ModelState.IsValid)
    {
        // Process the book
        return RedirectToAction(nameof(Index));
    }
    return View(book);
}
```

### Model Design

```csharp
/// <summary>
/// Represents a book in the library system.
/// </summary>
public class Book
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets the book title.
    /// </summary>
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
    [Display(Name = "Book Title")]
    public string Title { get; set; } = string.Empty;
}
```

## Copilot in Code Reviews

### For PR Authors

Use Copilot to:
1. **Self-review code**: Ask Copilot to review your changes
   ```
   @copilot review this PR for potential issues
   ```

2. **Generate descriptions**: 
   ```
   @copilot summarize these changes for the PR description
   ```

3. **Suggest tests**:
   ```
   @copilot what tests should I add for these changes?
   ```

### For PR Reviewers

Use Copilot to:
1. **Understand changes**:
   ```
   @copilot explain what this code does
   ```

2. **Identify issues**:
   ```
   @copilot find potential bugs in this implementation
   ```

3. **Suggest improvements**:
   ```
   @copilot how can this be improved?
   ```

## Advanced Copilot Features

### 1. Multi-file Edits

When making changes across multiple files:
```
Update the Book model to include Genre property:
1. Add Genre property to Models/Book.cs
2. Update Create.cshtml view to include Genre input
3. Update BooksController to handle Genre
4. Add Genre validation tests
```

### 2. Pattern Learning

Copilot learns from your codebase. To improve suggestions:
- Keep consistent naming conventions
- Use similar patterns across files
- Add comments explaining complex logic
- Document public APIs with XML comments

### 3. Context Management

Maximize Copilot's effectiveness:
- **Open related files** in tabs
- **Use workspace mode** for cross-file understanding
- **Reference existing code** in your prompts
- **Close unrelated files** to reduce noise

## Troubleshooting Copilot

### Suggestions Not Relevant?

1. **Check context**: Are the right files open?
2. **Be more specific**: Add detailed comments
3. **Reference examples**: Point to similar code
4. **Use Chat**: Ask explicitly instead of waiting for suggestions

### Copilot Suggests Wrong Pattern?

1. **Review custom instructions**: Check `.github/copilot-instructions.md`
2. **Update prompts**: Be more explicit about requirements
3. **Provide examples**: Show the pattern you want
4. **Use `/` commands**: Be directive with what you need

## Learning Resources

- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [Copilot Best Practices](https://github.blog/2023-06-20-how-to-write-better-prompts-for-github-copilot/)
- [Using Copilot Chat](https://docs.github.com/en/copilot/github-copilot-chat/using-github-copilot-chat)
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)

## Tips from the Team

💡 **Tip 1**: Use Copilot to explain unfamiliar code before modifying it

💡 **Tip 2**: Let Copilot generate boilerplate, then customize for your needs

💡 **Tip 3**: Use Copilot Chat to brainstorm solutions before coding

💡 **Tip 4**: Ask Copilot to review your code before committing

💡 **Tip 5**: Use Copilot to generate commit messages: `@copilot write a commit message for these changes`

## Feedback and Improvements

Found a better way to use Copilot in this project? 
- Open a PR to update this document
- Share in team discussions
- Add examples to `.github/copilot-instructions.md`

---

**Remember**: GitHub Copilot is a tool to enhance your productivity, not replace your judgment. Always review and test suggested code!
