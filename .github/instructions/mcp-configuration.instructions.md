---
applyTo: "**/{mcp.json,devcontainer.json,settings.json}"
---

# MCP (Model Context Protocol) Configuration Instructions

This project includes MCP server configurations to enhance AI-assisted development workflows.

## What is MCP?

Model Context Protocol (MCP) is an open standard that allows AI assistants (like GitHub Copilot, Claude, etc.) to connect to external tools and data sources. MCP servers provide additional capabilities beyond the AI's built-in knowledge.

## Configured MCP Servers

The MCP configuration is in `.vscode/mcp.json`. Here are the servers configured:

### 1. GitHub (`@modelcontextprotocol/server-github`)

**Purpose**: Interact with GitHub repositories, issues, pull requests, and code.

**Capabilities**:

- Search repositories, issues, and PRs
- Read/write issues and pull requests
- Browse repository contents
- Manage branches and commits
- Code search across repositories

**Setup**: Requires a GitHub Personal Access Token (prompted on first use).

### 2. Filesystem (`@modelcontextprotocol/server-filesystem`)

**Purpose**: Read and write files within the workspace.

**Capabilities**:

- Read file contents
- Write/create files
- List directory contents
- Search files by pattern
- Move and rename files

**Scope**: Restricted to the workspace folder for security.

### 3. Memory (`@modelcontextprotocol/server-memory`)

**Purpose**: Persistent knowledge graph for storing and retrieving context across sessions.

**Capabilities**:

- Store key-value pairs and relationships
- Build knowledge graphs about the project
- Persist context between conversations
- Track decisions and rationale

**Use case**: Let the AI remember project decisions, architecture choices, and context.

### 4. Fetch (`@modelcontextprotocol/server-fetch`)

**Purpose**: Fetch and read web content.

**Capabilities**:

- HTTP GET requests to URLs
- Read web pages and documentation
- Fetch API responses
- Download remote content for analysis

**Use case**: Reference external documentation, APIs, or resources during development.

### 5. Sequential Thinking (`@modelcontextprotocol/server-sequential-thinking`)

**Purpose**: Advanced reasoning and problem-solving through structured thinking.

**Capabilities**:

- Break down complex problems
- Step-by-step reasoning
- Dynamic thought revision
- Branching exploration paths

**Use case**: Complex architecture decisions, debugging, or algorithm design.

### 6. Playwright (`@anthropic/mcp-server-playwright`)

**Purpose**: Browser automation and web testing.

**Capabilities**:

- Navigate web pages
- Take screenshots
- Interact with page elements
- Run end-to-end tests
- Extract page content

**Use case**: Test the web application UI, generate screenshots for documentation.

### 7. Git (`@anthropic/mcp-server-git`)

**Purpose**: Git operations on the repository.

**Capabilities**:

- View git log and history
- Check diffs and changes
- View branches and tags
- Search git history
- Analyze commit patterns

**Use case**: Code review, understanding change history, and git operations.

## Setup Instructions

### Prerequisites

- Node.js 18+ installed
- `npx` available in PATH

### First-Time Setup

1. **GitHub Token**: Create a GitHub PAT at https://github.com/settings/tokens
   - Required scopes: `repo`, `read:org`, `read:user`
   - The token will be prompted when the GitHub MCP server is first used

2. **Verify Node.js**:

   ```bash
   node --version  # Should be 18+
   npx --version   # Should be available
   ```

3. **Open the project in VS Code** — MCP servers start automatically when needed.

## Usage Tips

### In Copilot Chat

Once MCP servers are running, you can ask Copilot to:

```
# GitHub operations
"Search for open issues labeled 'bug'"
"Create a new issue for adding search functionality"
"What PRs are pending review?"

# File operations
"List all controller files"
"Find files containing 'IBookService'"

# Memory
"Remember that we decided to use repository pattern"
"What architecture decisions have we made?"

# Fetch
"Read the ASP.NET Core documentation on middleware"
"Fetch the latest .NET 9 release notes"

# Git
"Show me the last 10 commits"
"What files changed in the last commit?"
"Show the diff for BooksController.cs"

# Sequential Thinking
"Help me design the data access layer architecture"
"Walk through debugging this null reference exception"
```

## Adding New MCP Servers

To add a new MCP server, edit `.vscode/mcp.json`:

```json
{
  "mcp": {
    "servers": {
      "new-server": {
        "command": "cmd",
        "args": ["/c", "npx", "-y", "@scope/server-name"],
        "env": {
          "API_KEY": "${input:api_key}"
        }
      }
    }
  }
}
```

## Useful MCP Servers (Not Pre-configured)

| Server       | Package                                 | Purpose                   |
| ------------ | --------------------------------------- | ------------------------- |
| Brave Search | `@anthropic/mcp-server-brave-search`    | Web search                |
| SQLite       | `@anthropic/mcp-server-sqlite`          | Database operations       |
| Postgres     | `@modelcontextprotocol/server-postgres` | PostgreSQL access         |
| Slack        | `@modelcontextprotocol/server-slack`    | Slack integration         |
| Azure        | `@azure/mcp`                            | Azure resource management |

## Troubleshooting

### Server won't start

- Verify Node.js 18+ is installed: `node --version`
- Clear npm cache: `npm cache clean --force`
- Try manual install: `npx @modelcontextprotocol/server-github`

### Permission errors

- Ensure the GitHub token has required scopes
- Filesystem server is restricted to workspace folder
- Check firewall for fetch server

### Performance

- MCP servers run as separate processes
- They start on-demand and can be stopped
- Use VS Code's MCP panel to monitor server status
