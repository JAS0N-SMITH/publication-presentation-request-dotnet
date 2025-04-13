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
- .NET 8 SDK
- Node.js (for frontend development)
- Azure account for Entra ID and Blob Storage setup

### Setup Instructions
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/dotnet-github-agent-test.git
   ```
2. Navigate to the project directory:
   ```bash
   cd dotnet-github-agent-test
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

