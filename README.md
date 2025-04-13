# dotnet-github-agent-test
Testing github's new agent on a fresh dotnet application

## Background

In many research and academic institutions, managing the workflow around submitting publications, presentations, and associated abstracts for review and approval is often handled through disconnected tools or manual communication. This results in lost data, missed deadlines, and lack of traceability.

This system is designed to formalize and streamline the request, review, and approval process for publications and presentations. It introduces roles such as requestors, approvers, and administrators, with tailored capabilities to manage the lifecycle of submissions. The application will support structured data capture, reviewer workflows, audit trails, and basic administrative capabilities for testing and exception handling.

## Features
- Role-based access control for Requestors, Approvers, and Admins.
- Multi-step forms for structured data capture.
- Configurable multi-level approval workflows.
- Visual progress timeline for tracking request stages.
- Audit trails for all user actions.

## Getting Started

### Prerequisites
- .NET 9 SDK
- Azure account for Entra ID and Blob Storage setup
- SQL Server Management Studio (for database management)

### Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/publication-presentation-request-dotnet.git
   ```
2. Navigate to the project directory:
   ```bash
   cd publication-presentation-request-dotnet
   ```
3. Install backend dependencies:
   ```bash
   dotnet restore
   ```
4. Install frontend dependencies:
   ```bash
   cd frontend && npm install
   ```
5. Run the application:
   ```bash
   dotnet run
   ```

## Technology Stack
- **Frontend**: Blazor (WebAssembly)
- **Backend**: ASP.NET Core Web API
- **Auth**: Azure Entra ID
- **Database**: Microsoft SQL Server
- **File Storage**: Azure Blob Storage

## UML Diagram
![Component Diagram](UMLimage.png)

## Contributing
We welcome contributions! Please follow these steps:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with a detailed description of your changes.

## CI/CD pipeline using GitHub Actions

### It includes the following steps:

#### Build and Test

Restores dependencies, builds the solution, and runs tests for both frontend and backend.

#### Deploy Backend

Deploys the backend to Azure App Service using the azure/webapps-deploy action.

#### Deploy Frontend

Builds the frontend and deploys it to Azure Static Web Apps using the Azure/static-web-apps-deploy action.

_Note: Make sure to add the required secrets (AZURE_CREDENTIALS and AZURE_STATIC_WEB_APPS_API_TOKEN) to your GitHub repository settings for the deployment steps to work._