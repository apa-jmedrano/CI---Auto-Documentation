# AI PR Auto Documentation + Review

This project is a simple, demo-ready GitHub Actions setup that automatically reviews pull requests, generates documentation, and posts PR feedback for a C#/.NET app.

## What This Project Does

On every pull request, automation can:
- Review changed files with OpenAI Codex.
- Generate/update:
  - `docs/CHANGELOG_AUTO.md`
  - `docs/PR_SUMMARY.md`
- Detect TODO/FIXME patterns and include warnings in the summary.
- Check whether tests were updated and reflect this in the summary.
- Post an AI PR summary comment.
- Grade the PR with a 10-point score.

## Project Structure

```
.github/workflows/
  ci.yml
  auto-doc-review.yml
  grade.yml

.codex/prompts/
  review-doc.prompt.md

docs/
  CHANGELOG_AUTO.md
  PR_SUMMARY.md

src/
  StringUtils.cs
  StringUtils.csproj

tests/
  StringUtilsTests.cs
  StringUtils.Tests.csproj
```

## Local Run (Codespaces / VS Code Friendly)

Prerequisite:
- .NET SDK 10+

Run locally:

```bash
dotnet restore tests/StringUtils.Tests.csproj
dotnet test tests/StringUtils.Tests.csproj --configuration Release
```

## GitHub Actions Workflows

### 1) CI (`.github/workflows/ci.yml`)
- Triggers on:
  - `pull_request`
  - `push` to `main`
- Steps:
  - Set up .NET
  - Restore dependencies
  - Run tests with `dotnet test`

### 2) Auto Documentation + Review (`.github/workflows/auto-doc-review.yml`)
- Triggers on:
  - `pull_request` events: `opened`, `synchronize`
  - `workflow_dispatch` (manual run)
- Steps:
  - Checkout code
  - Run `openai/codex-action@v1` using prompt file `.codex/prompts/review-doc.prompt.md`
  - Uses repository secret: `OPENAI_API_KEY`
  - Ensures and updates docs outputs
  - Commits generated docs changes
  - Posts/updates a PR summary comment

### 3) PR Grade (`.github/workflows/grade.yml`)
- Triggers on:
  - `pull_request` events: `opened`, `synchronize`, `reopened`
  - `workflow_dispatch`
- Scoring:
  - Tests pass: 6 points
  - Docs updated: 2 points
  - Small diff (<= 200 changed lines): 2 points
- Posts/updates grading comment on the PR

## C# Demo App

`src/StringUtils.cs` includes:
- `ReverseText(string text)`
- `NormalizeSpaces(string text)`
- `ToSlug(string text)`

`tests/StringUtilsTests.cs` includes deterministic xUnit tests for all functions.

## Required GitHub Secret

Add this repository secret before running AI review workflow:
- `OPENAI_API_KEY`

GitHub path:
- `Settings` -> `Secrets and variables` -> `Actions` -> `New repository secret`

## How PR Review and Auto Documentation Work

1. Open or update a pull request.
2. `auto-doc-review.yml` runs Codex with `.codex/prompts/review-doc.prompt.md`.
3. Codex updates only:
   - `docs/CHANGELOG_AUTO.md`
   - `docs/PR_SUMMARY.md`
4. Workflow commits documentation updates.
5. Workflow posts an "AI PR Summary" comment in the PR.

## How Grading Works

When a PR is opened or updated, `grade.yml`:
1. Runs tests.
2. Checks if docs outputs were updated in PR files.
3. Computes total changed lines from PR file stats.
4. Publishes grade comment with score breakdown.

## Demo Ready

This repository is ready for a GitHub UI demo.

Suggested demo flow:
1. Create a feature branch.
2. Change `src/StringUtils.cs` and/or tests.
3. Open a PR.
4. Show:
  - CI test results
  - AI-generated changelog and summary
  - AI PR comment
  - Automated PR grade
