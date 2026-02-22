# Security Best Practices Instructions

ALL code MUST follow these security standards. Security is non-negotiable.

## Input Validation

- **Never trust user input** — validate everything server-side
- Use Data Annotations (`[Required]`, `[StringLength]`, `[Range]`, `[RegularExpression]`)
- Use `[Bind]` attribute to prevent over-posting attacks:
  ```csharp
  [HttpPost]
  public IActionResult Create([Bind("Title,Author,ISBN")] Book book)
  ```
- Validate file uploads: check type, size, and content
- Sanitize all strings before displaying or storing

## Cross-Site Scripting (XSS) Prevention

- Razor automatically HTML-encodes output — do NOT use `@Html.Raw()` with user data
- Use Content Security Policy (CSP) headers
- Validate and sanitize any user input that will be rendered
- Use `HtmlEncoder` when manually encoding is needed

## Cross-Site Request Forgery (CSRF)

- ALL POST/PUT/DELETE actions MUST have `[ValidateAntiForgeryToken]`
- ALL forms MUST include anti-forgery tokens (`asp-antiforgery="true"`)
- Use `[AutoValidateAntiforgeryToken]` at controller level when possible

## Authentication & Authorization

- Use ASP.NET Core Identity or external providers
- Never store passwords in plain text
- Use `[Authorize]` attribute to protect endpoints
- Follow principle of least privilege
- Use role-based or policy-based authorization

## Sensitive Data

- **Never hardcode secrets** (connection strings, API keys, passwords)
- Use User Secrets for development: `dotnet user-secrets`
- Use environment variables or Azure Key Vault for production
- Never log sensitive data (passwords, tokens, PII)
- Add sensitive files to `.gitignore`
- Never commit `.env` files, certificates, or key files

## Dependency Security

- Keep NuGet packages up to date
- Run `dotnet list package --vulnerable` regularly
- Use Dependabot or GitHub security advisories
- Review transitive dependencies for known vulnerabilities

## HTTP Security Headers

Configure these in `Program.cs`:
```csharp
app.UseHsts();
app.UseHttpsRedirection();
```

Recommended headers:
- `X-Content-Type-Options: nosniff`
- `X-Frame-Options: DENY`
- `X-XSS-Protection: 1; mode=block`
- `Referrer-Policy: strict-origin-when-cross-origin`
- `Content-Security-Policy: default-src 'self'`

## Logging Security

- Use structured logging with `ILogger<T>`
- Log security events (login failures, authorization denials)
- **Never log**: passwords, tokens, credit card numbers, SSNs, or PII
- Mask sensitive data in logs: `****` for partial values
- Use appropriate log levels:
  - `LogWarning` for failed authentication
  - `LogError` for security exceptions
  - `LogCritical` for potential breaches

## Error Handling

- Never expose stack traces or internal details to users
- Use custom error pages for production
- Return generic error messages to clients
- Log full error details server-side only
- Use Problem Details (RFC 7807) format for API errors
