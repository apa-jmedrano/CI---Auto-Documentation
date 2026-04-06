# AI PR Auto Documentation + Review

This project is a simple, demo-ready GitHub Actions setup for a C#/.NET web app that separates main-branch documentation generation from PR validation and PR evaluation.

## What This Project Does

This repository provides three workflows:
- Generate full app documentation after code is merged to `main`.
- Run build, tests, and error checks on pull requests.
- Evaluate pull requests and generate `docs/PR_SUMMARY.md` and `docs/CHANGELOG_AUTO.md`.

## Project Structure

```
.github/workflows/
  ci.yml
  auto-doc-review.yml
  grade.yml

.codex/prompts/
  review-doc.prompt.md
  system-doc.prompt.md

docs/
  APP_DOCUMENTATION.md
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

### 1) Main Documentation (`.github/workflows/grade.yml`)
- Trigger:
  - `push` to `main`
- Purpose:
  - Creates formal application documentation in `docs/APP_DOCUMENTATION.md`
  - Describes application use, connected servers, systems, services, and architecture based on repository contents
- Result:
  - Commits updated mainline documentation back to the repository

### 2) PR Tests And Errors (`.github/workflows/ci.yml`)
- Trigger:
  - `pull_request` events: `opened`, `synchronize`, `reopened`
- Purpose:
  - Restores dependencies
  - Builds the test project to surface compile errors
  - Runs tests when present

### 3) PR Evaluation (`.github/workflows/auto-doc-review.yml`)
- Triggers on:
  - `pull_request` events: `opened`, `synchronize`
  - `workflow_dispatch`
- Purpose:
  - Reviews changed files with AI
  - Generates `docs/PR_SUMMARY.md`
  - Generates `docs/CHANGELOG_AUTO.md`
  - Posts or updates a PR summary comment

## C# Demo App

`src/StringUtils.cs` includes:
- `ReverseText(string text)`
- `NormalizeSpaces(string text)`
- `ToSlug(string text)`

`tests/StringUtilsTests.cs` includes deterministic xUnit tests for all functions.

## Required GitHub Secret

Add this repository secret before running the AI-powered workflows:
- `OPENAI_API_KEY`

GitHub path:
- `Settings` -> `Secrets and variables` -> `Actions` -> `New repository secret`

## How The Three Workflows Work

1. When code is merged into `main`, `grade.yml` generates or refreshes `docs/APP_DOCUMENTATION.md`.
2. When a pull request is opened or updated, `ci.yml` builds the project and runs tests to surface errors.
3. When a pull request is opened or updated, `auto-doc-review.yml` evaluates the PR diff and updates:
  - `docs/CHANGELOG_AUTO.md`
  - `docs/PR_SUMMARY.md`
4. The PR evaluation workflow also posts a PR summary comment.

## Generated Documentation Files

- `docs/APP_DOCUMENTATION.md`: formal application documentation for the main branch
- `docs/PR_SUMMARY.md`: pull request summary for reviewers
- `docs/CHANGELOG_AUTO.md`: pull request changelog notes

## Demo Ready

This repository is ready for a GitHub UI demo.

Suggested demo flow:
1. Create a feature branch.
2. Change `src/StringUtils.cs` and/or tests.
3. Open a PR.
4. Show:
  - PR build and test results
  - AI-generated PR summary and changelog
  - AI PR comment
5. Merge the PR to `main`.
6. Show:
  - Generated application documentation in `docs/APP_DOCUMENTATION.md`
