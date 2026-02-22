# Git Workflow & Best Practices Instructions

Follow these Git workflow standards for all contributions.

## Branch Strategy

### Branch Naming Convention
```
<type>/<short-description>

Examples:
  feature/add-book-search
  fix/modal-close-button
  docs/update-readme
  refactor/extract-book-service
  test/add-controller-tests
  chore/update-dependencies
```

### Branch Types
| Prefix     | Purpose                      |
|------------|------------------------------|
| `feature/` | New features                 |
| `fix/`     | Bug fixes                    |
| `docs/`    | Documentation changes        |
| `refactor/`| Code refactoring             |
| `test/`    | Adding or updating tests     |
| `chore/`   | Maintenance, dependencies    |
| `hotfix/`  | Urgent production fixes      |

### Protected Branches
- `main` — production-ready code, requires PR review
- `develop` — integration branch (if using Gitflow)

## Commit Standards

Follow [Conventional Commits](https://www.conventionalcommits.org/):

```
<type>(<scope>): <description>

[optional body]

[optional footer(s)]
```

### Commit Types
| Type       | Description                                |
|------------|--------------------------------------------|
| `feat`     | New feature                                |
| `fix`      | Bug fix                                    |
| `docs`     | Documentation only                         |
| `style`    | Formatting, no code change                 |
| `refactor` | Code change, no new feature or fix         |
| `perf`     | Performance improvement                    |
| `test`     | Adding/updating tests                      |
| `build`    | Build system or external dependency changes|
| `ci`       | CI/CD configuration changes                |
| `chore`    | Other changes (not src/test)               |
| `revert`   | Reverting a previous commit                |

### Commit Rules
- Use imperative mood: "add feature" not "added feature"
- First line max 72 characters
- Reference issues: `fix: resolve null pointer (#42)`
- One logical change per commit
- Never commit generated files, build outputs, or secrets
- Always run tests before committing

### Good vs Bad Commits

```bash
# GOOD
feat(books): add search functionality to index page
fix(controller): handle null book ID in edit action
test(books): add unit tests for delete action
docs: update API endpoint documentation

# BAD
update stuff
fix bug
WIP
asdfgh
changed files
```

## Pull Request Workflow

1. Create a feature branch from `main`
2. Make focused, incremental commits
3. Push branch and open a Pull Request
4. Fill out the PR template completely
5. Request review from at least one team member
6. Address review feedback promptly
7. Squash or rebase if requested
8. Merge after approval (prefer squash merge for clean history)

### PR Requirements
- [ ] Descriptive title following commit conventions
- [ ] PR template filled out completely
- [ ] All CI checks passing
- [ ] At least one approving review
- [ ] No merge conflicts
- [ ] Tests added/updated for changes
- [ ] Documentation updated if needed

## Git Best Practices

- **Pull before push**: `git pull --rebase origin main`
- **Rebase over merge** for feature branches (keeps linear history)
- **Never force push** to shared branches (`main`, `develop`)
- **Delete merged branches** after PR is merged
- **Use `.gitignore`** properly — never commit IDE files, build outputs, or secrets
- **Write meaningful commit messages** — your future self will thank you
- **Keep commits atomic** — each commit should be a single logical change
