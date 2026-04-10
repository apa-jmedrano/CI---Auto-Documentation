# StringUtils

## Project Overview
StringUtils is a .NET library designed to provide utility functions for string manipulation and validation. The library includes features such as text normalization and palindrome checking, making it a useful tool for developers working with string data.

## Architecture / Tech Stack
- **Framework**: .NET 10.0
- **Languages**: C#
- **Testing Framework**: xUnit
- **Package Management**: NuGet
- **Code Quality Tools**: Coverlet for code coverage
- **Configuration**: appsettings.json for connection strings

## Approval / Business Workflow
This project follows a standard development workflow:
1. **Feature Development**: New features are developed in feature branches.
2. **Code Review**: Pull requests are created for code review.
3. **Testing**: Automated tests are run to ensure code quality.
4. **Deployment**: Once approved, changes are merged into the main branch and deployed.

## Database / Persistence Layer
This project includes configuration for multiple SQL Server databases, which are defined in the `appsettings.json` file. The connection strings for the databases are as follows:
- **Primary Database**: MainAppDb
- **Reporting Database**: ReportingDb
- **Archive Database**: ArchiveDb

## Deployment / Infrastructure
Currently, there is no specific deployment infrastructure defined for this library, as it is intended to be used as a library in other applications. However, it can be packaged and published to NuGet for distribution.

## Local Setup / Run Instructions
To set up and run the StringUtils project locally, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   cd StringUtils
   ```

2. **Install Dependencies**:
   Ensure you have the .NET SDK installed. You can download it from [the official .NET website](https://dotnet.microsoft.com/download).

3. **Build the Project**:
   ```bash
   dotnet build src/StringUtils.csproj
   ```

4. **Run Tests**:
   To run the unit tests, navigate to the tests directory and execute:
   ```bash
   dotnet test tests/StringUtils.Tests.csproj
   ```

5. **Usage**:
   You can use the StringUtils library in your own projects by referencing the compiled DLL or by adding it as a NuGet package once published.

## Additional Information
For contributions, please follow the standard GitHub workflow for pull requests. Ensure that all new features are covered by tests and that existing tests pass before submitting your changes.
