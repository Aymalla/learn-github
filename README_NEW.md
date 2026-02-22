# Learn GitHub 🚀

A comprehensive learning environment for exploring GitHub features, GitHub Actions, CI/CD pipelines, and **GitHub Copilot integration** in a real-world ASP.NET Core application.

## 📋 Project Overview

This repository demonstrates:
- ✨ **Modern .NET Development** - ASP.NET Core 9.0 MVC application
- 🤖 **GitHub Copilot Integration** - Best practices and custom instructions
- 🔄 **CI/CD Workflows** - Automated build, test, and deployment pipelines
- 📦 **GitHub Actions** - Workflow automation and DevOps practices
- 🧪 **Testing & Quality** - Unit testing with xUnit and code quality checks
- 📚 **Documentation** - Comprehensive guides and templates

## 🛠️ Technology Stack

- **Framework**: .NET 9.0 (ASP.NET Core MVC)
- **Language**: C# 12
- **Testing**: xUnit
- **Frontend**: Razor Views, HTML5, CSS3, JavaScript
- **CI/CD**: GitHub Actions
- **AI Assistant**: GitHub Copilot

## 🚀 Quick Start

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Git](https://git-scm.com/)
- Code editor with GitHub Copilot support (VS Code recommended)

### Setup

```bash
# Clone the repository
git clone https://github.com/Aymalla/learn-github.git
cd learn-github

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
cd src/web-app
dotnet run

# Run tests
dotnet test
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## 🤖 GitHub Copilot Integration

This repository is optimized for GitHub Copilot usage with:

### Custom Copilot Instructions
- **[.github/copilot-instructions.md](.github/copilot-instructions.md)** - Project-specific guidelines for Copilot
- **[.github/COPILOT_BEST_PRACTICES.md](.github/COPILOT_BEST_PRACTICES.md)** - Best practices and workflows

### Copilot-Friendly Features
- ✅ Comprehensive XML documentation comments
- ✅ Consistent coding patterns and conventions
- ✅ Well-structured project organization
- ✅ Example code for common patterns
- ✅ Inline comments explaining complex logic

### Using Copilot in This Project

**Quick Tips:**
```csharp
// Create a new controller following the BooksController pattern
// Copilot will suggest code matching project conventions

// Generate unit tests for a method
// Use: /tests for MethodName

// Explain complex code
// Use: @copilot explain this code
```

See [Copilot Best Practices](.github/COPILOT_BEST_PRACTICES.md) for detailed guidance.

## 🔄 GitHub Actions Workflows

We explore how GitHub Actions automate the build and release processes:

### Active Workflows

- ✅ **Build & Test Workflow** (`dotnet-ci.yml`)
  - Triggered on: Pull requests, pushes to main/develop
  - Runs: Build, test, code coverage
  
- 🤖 **Copilot PR Review** (`copilot-pr-review.yml`)
  - Triggered on: Pull request events
  - Adds: Copilot usage tips for reviewers

- 🚀 **Release Workflow**
  - Triggered on: Pushes to release branch
  - Runs: Build, test, deploy

### Workflow Features Demonstrated

- [x] Different trigger events (push, PR, manual dispatch)
- [x] Conditional execution based on event types
- [x] Secure handling of secrets and environment variables
- [x] Reusable actions and workflows
- [x] Code quality and security scanning
- [x] Test coverage reporting

## 📦 Caching vs Artifacts

**Caching**: Stores dependencies/build outputs for reuse across workflow runs
- Speeds up builds by avoiding re-downloads
- Shared between workflow runs
- Example: NuGet packages, npm modules

**Artifacts**: Stores files generated during a workflow
- Share files between jobs
- Download after workflow completion
- Example: Test results, build outputs

## 🏗️ Project Structure

```
learn-github/
├── .github/
│   ├── workflows/              # GitHub Actions workflows
│   ├── ISSUE_TEMPLATE/         # Issue templates
│   ├── copilot-instructions.md # Copilot custom instructions
│   ├── COPILOT_BEST_PRACTICES.md
│   └── PULL_REQUEST_TEMPLATE.md
├── src/
│   └── web-app/
│       ├── Controllers/        # MVC Controllers
│       ├── Models/            # Data models
│       ├── Views/             # Razor views
│       ├── wwwroot/           # Static files
│       └── test/              # Unit tests
├── docs/                      # Documentation
├── CONTRIBUTING.md           # Contribution guidelines
└── README.md                 # This file
```

## 🧪 Testing

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test /p:CollectCoverage=true

# Run specific test
dotnet test --filter "FullyQualifiedName~BooksControllerTests"
```

## 📖 Documentation

- **[Contributing Guide](CONTRIBUTING.md)** - How to contribute to this project
- **[Copilot Best Practices](.github/COPILOT_BEST_PRACTICES.md)** - Using Copilot effectively
- **[GitHub Actions Guide](docs/github-actions.md)** - Workflow documentation
- **[Discussion Notes](docs/disussion.md)** - Additional notes

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for:
- Development setup
- Coding standards
- Commit guidelines
- Pull request process
- Using GitHub Copilot

## 📝 License

This project is licensed under the terms specified in the [LICENSE](LICENSE) file.

## 🎯 Learning Objectives

Through this repository, you'll learn:

1. **GitHub Copilot**
   - Writing effective prompts
   - Using custom instructions
   - Code review with Copilot
   - Testing with Copilot

2. **GitHub Actions**
   - Workflow creation and triggers
   - Job dependencies and artifacts
   - Secrets management
   - Reusable workflows

3. **CI/CD Best Practices**
   - Automated testing
   - Code quality checks
   - Security scanning
   - Deployment automation

4. **Modern .NET Development**
   - ASP.NET Core MVC patterns
   - Unit testing with xUnit
   - Code organization
   - Best practices

## 🔗 Resources

- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [GitHub Actions Documentation](https://docs.github.com/en/actions)
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [.NET 9.0 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-9)

## 💬 Questions or Feedback?

- **Issues**: [Create an issue](../../issues)
- **Discussions**: [Start a discussion](../../discussions)
- **Pull Requests**: [Contribute](../../pulls)

---

**Happy Learning and Coding with GitHub Copilot! 🚀**
