# Compatibility and Version Requirements

## Frontend: Blazor (WebAssembly)
- **Framework**: .NET 8 (latest stable version as of April 2025)
- **Browser Compatibility**: Modern browsers (Chrome, Edge, Firefox, Safari)
- **UI Libraries**: MudBlazor or Radzen (latest versions compatible with .NET 8)

## Backend: ASP.NET Core Web API
- **Framework**: .NET 8
- **Middleware**: Compatible with Azure Entra ID and Azure Blob Storage SDK
- **Database ORM**: Entity Framework Core 8

## Authentication: Azure Entra ID
- **SDK**: Microsoft.Identity.Web (latest version compatible with .NET 8)
- **SSO**: Group-based role assignment configuration

## Database: Microsoft SQL Server
- **Version**: SQL Server 2022 or Azure SQL Database (latest stable version)
- **Driver**: Microsoft.Data.SqlClient (latest version compatible with .NET 8)

## File Storage: Azure Blob Storage
- **SDK**: Azure.Storage.Blobs (latest version compatible with .NET 8)
- **Configuration**: Proper connection string setup and permissions

## Development Environment
- **IDE**: Visual Studio 2022 (latest version) or Visual Studio Code with .NET extensions
- **OS**: macOS (primary) and Windows (for cross-platform testing)

## Testing Frameworks
- **Unit Testing**: xUnit or NUnit (latest versions)
- **Integration Testing**: Microsoft.AspNetCore.TestHost
- **UI Testing**: bUnit for Blazor components

## Deployment
- **Cloud**: Azure App Service for hosting Blazor WebAssembly and ASP.NET Core API
- **CI/CD**: GitHub Actions with Azure DevOps integration