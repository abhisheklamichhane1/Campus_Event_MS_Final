# Campus_Event_Management_Sys_Final

The Campus Event Management System (CampusEventMS) is a comprehensive application for managing campus events. It includes features for user registration, authentication, event listing and registration, category management, and event search and filtering.

## Prerequisites

Before running the application, ensure you have the following installed:

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (local or remote)
- [Visual Studio](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload)

## Setup Instructions

1. **Clone the Repository**

   ```sh
   git clone https://github.com/your-repo/CampusEventMS.git
   cd CampusEventMS

   
2. **Configure the Database

Open the appsettings.json file in the root of the project.

Update the DefaultConnection string with your SQL Server connection details.

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CampusEventMS;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}

3. **Run Database Migrations

Open the Package Manager Console in Visual Studio (Tools > NuGet Package Manager > Package Manager Console) and run the following command:

Update-Database

This command will apply the latest migrations to your database, creating the necessary tables and schema.

4. **Build and Run the Project

 -In Visual Studio, set the CampusEventMS project as the startup project.
 -Press F5 or click the Run button to build and run the project.

## Using Swagger
Swagger provides a user-friendly interface for interacting with your API endpoints. Once the application is running, follow these steps to use Swagger:

1. **Access Swagger UI

Open your web browser and navigate to http://localhost:5000/swagger (or the appropriate port if different).

2. **Interact with API Endpoints

Swagger UI will display all available API endpoints. You can interact with these endpoints directly from the Swagger interface.

## Example API Endpoints
Here are some example endpoints you can test using Swagger:

User Registration

Endpoint: POST /api/account/register
Description: Registers a new user.
Request Body:
{
    "Email": "user@example.com",
    "Password": "Password123!",
    "ConfirmPassword": "Password123!"
}
## Troubleshooting
Database Connection Issues

Ensure your SQL Server is running and the connection string in appsettings.json is correct.
Verify that the database exists and the user has appropriate permissions.
Migration Errors

Check the Package Manager Console output for any errors during migration.
Ensure that all migrations are applied and up to date.
Swagger Not Loading

Ensure Swagger middleware is correctly configured in the Startup.cs.
Check if the application is running on the expected port.
## Additional Notes
Environment Variables

You can use environment variables to override settings in appsettings.json. This is useful for deployment and testing in different environments.
Swagger Integration

Swagger UI is available at http://localhost:5000/swagger to explore and test your API endpoints.
## Conclusion
By following these steps, you can set up, configure, and run the Campus Event Management System on your local machine. Swagger provides a convenient interface to explore and interact with your API, making it easier to test and debug your application. If you encounter any issues or have questions, feel free to reach out for support.

