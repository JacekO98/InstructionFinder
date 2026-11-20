# Instruction Finder

A web application for finding work instructions by part number and machine. Users enter a part number, select a machine (DW), and browse the associated instructions. Users with the `Technolog` role can add and edit instructions.

## Technology stack

- .NET 8 / ASP.NET Core Blazor Interactive Server
- Entity Framework Core 8
- Microsoft SQL Server
- ASP.NET Core Identity
- MailKit for email delivery

## Solution structure

| Project | Purpose |
| --- | --- |
| `Instruction_finder` | Web application, Blazor pages, and host configuration |
| `IF.CoreBusiness` | Domain models for instructions, parts, and machines |
| `IF.UseCase` | Repository interfaces and use cases |
| `IF.Plugins/IF.Plugins.EFCoreSqlServer` | SQL Server repository, EF Core context, and Identity migrations |
| `IF.Plugins.InMemory` | Sample-data repository intended for the `Testing` environment |
| `DB` | Supporting data files in CSV and TXT formats |

## Requirements

- .NET 8 SDK
- SQL Server, such as a local SQL Server Express instance
- Access to an SMTP server if the application should send account confirmation and password reset emails

## Configuration

The application uses SQL Server in normal operation. Set the `ConnectionStrings:InstructionMenagement` connection string before starting the application. Example for local SQL Server Express with Windows Authentication:

```text
Server=localhost\SQLEXPRESS;Database=InstructionManagement;Trusted_Connection=True;TrustServerCertificate=True
```

Do not use the `master` database for application data. The repository contains a local connection string in `appsettings.Development.json` and `appsettings.Production.json`; update it for your environment or override it with environment variables. Do not commit passwords or other secrets to the repository.

For local development, configure the connection string and SMTP settings with User Secrets from the repository root:

```powershell
dotnet user-secrets set "ConnectionStrings:InstructionMenagement" "Server=localhost\SQLEXPRESS;Database=InstructionManagement;Trusted_Connection=True;TrustServerCertificate=True" --project .\Instruction_finder\Instruction_finder.csproj
dotnet user-secrets set "Email:FromName" "Instruction Finder" --project .\Instruction_finder\Instruction_finder.csproj
dotnet user-secrets set "Email:FromAddress" "noreply@example.com" --project .\Instruction_finder\Instruction_finder.csproj
dotnet user-secrets set "Email:SmtpServer" "smtp.example.com" --project .\Instruction_finder\Instruction_finder.csproj
dotnet user-secrets set "Email:SmtpPort" "587" --project .\Instruction_finder\Instruction_finder.csproj
dotnet user-secrets set "Email:Username" "noreply@example.com" --project .\Instruction_finder\Instruction_finder.csproj
dotnet user-secrets set "Email:AppPassword" "replace-with-an-app-password" --project .\Instruction_finder\Instruction_finder.csproj
```

`SmtpIdentityEmailSender` requires the SMTP settings. Configure them before registering an account, because registration sends an email confirmation link.

### PDF files

The PDF viewer currently builds file paths from a local Windows directory hard-coded in `PDFViewerComponent.razor`. The `PdfSettings:RootPath` setting in `appsettings.Production.json` is not currently used by the component. Update the PDF location handling before running the application in another environment. The path stored in the database must match the format expected by the component.

> **Security note:** The `/pdf` endpoint accepts a path from the URL and currently permits absolute paths. Before deploying the application, restrict file access to the configured directory containing the instructions.

## Database setup

Migrations are in the `IF.Plugins/IF.Plugins.EFCoreSqlServer` project. If the EF Core CLI is not installed, install it with:

```powershell
dotnet tool install --global dotnet-ef --version 8.0.23
```

Create or update the database from the repository root:

```powershell
dotnet ef database update --project .\IF.Plugins\IF.Plugins.EFCoreSqlServer\IF.Plugins.EFCoreSqlServer.csproj --startup-project .\Instruction_finder\Instruction_finder.csproj
```

Before applying migrations, make sure the connection string points to the intended database and the SQL account can create or modify it.

## Run locally

From the repository root:

```powershell
dotnet restore .\Instruction_finder.sln
dotnet run --project .\Instruction_finder\Instruction_finder.csproj
```

The application URL will be printed in the console. A Visual Studio launch profile is also included.

## Accounts and permissions

Authentication is provided by ASP.NET Core Identity. Accounts must confirm their email address. The add and edit pages require the `Technolog` role; newly registered accounts are not assigned this role automatically. An application or database administrator must create the role and assign it to the appropriate accounts.

## Using the application

1. Open the instruction search page.
2. Enter a part number and search.
3. Select a machine DW from the results.
4. Select an instruction to display its PDF preview.
5. To add or edit instructions, sign in with an account assigned the `Technolog` role.

## Known limitations

- The InMemory repository contains sample data; adding and editing instructions are not fully implemented in it.
- Instruction lookup for editing uses the PDF path, which is not enforced as unique in the database. If multiple records share a path, the selected record may be ambiguous.
- PDF file configuration currently depends on a local Windows path and should be generalized before deployment.


<img width="1905" height="568" alt="image" src="https://github.com/user-attachments/assets/396f7656-8680-4e7c-afa9-be856fc681a4" />
