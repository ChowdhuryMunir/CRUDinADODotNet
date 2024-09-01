# CRUD in ADO.NET

This repository contains a C# application demonstrating CRUD (Create, Read, Update, Delete) operations using ADO.NET. The project showcases how to interact with a SQL database through ADO.NET for managing data effectively.

## Features

- **CRUD Operations**: Supports full Create, Read, Update, and Delete functionalities.
- **ADO.NET**: Utilizes ADO.NET for database connectivity and operations.
- **SQL Server Integration**: Connects to SQL Server for data storage and management.
- **Data Validation**: Ensures data integrity with basic validation checks.
- **User Interface**: Provides a simple console or WinForms interface (depending on implementation) for interacting with data.

## Technologies Used

- **C#**: Programming language used for application development.
- **ADO.NET**: Data access technology for connecting to and working with SQL databases.
- **SQL Server**: Database system used for storing and managing data.
- **Windows Forms** : Windows Forms for creating desktop applications.

## Getting Started

### Prerequisites

Ensure you have the following installed:

- [Microsoft Visual Studio](https://visualstudio.microsoft.com/) with support for C# and .NET Framework
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or a compatible database system

### Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/ChowdhuryMunir/CRUDinADODotNet.git
   cd CRUDinADODotNet
   ```

2. **Open the Project**
   - Open the solution file (`.sln`) in Visual Studio.

3. **Update Database Connection String**
   - Open the `app.config` or `web.config` file (depending on the project type) and update the connection string:
     ```xml
     <connectionStrings>
       <add name="DefaultConnection" connectionString="Server=your_server;Database=your_database;User Id=your_user;Password=your_password;" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

4. **Build the Project**
   - Build the project in Visual Studio to restore NuGet packages and compile the application.

5. **Run the Application**
   - Start the application using Visual Studio. If it’s a console application, it will run in the terminal. For a Windows Forms application, it will open a graphical interface.
  
6. Login Credentials

- When prompted, use the following credentials to log in:
- Username: Munir
- Password: 01234

## Project Structure

- **Models**: Contains classes representing data structures used in the application.
- **Data Access Layer**: Includes classes and methods for interacting with the database using ADO.NET.
- **Business Logic Layer**: Implements the core logic for CRUD operations.
- **UI Layer**: Provides the user interface for interacting with the application (console or Windows Forms).

## Application Features

- **Create**: Form or method for adding new records to the database.
- **Read**: Methods or UI components for retrieving and displaying records.
- **Update**: Form or method for modifying existing records.
- **Delete**: Functionality to remove records from the database.

## Usage

Run the application to perform CRUD operations. Depending on the project type, you may interact with the application through a console interface or a Windows Forms GUI.

## Contributing

Contributions are welcome! To contribute:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m 'Add new feature'`).
4. Push the branch (`git push origin feature/your-feature`).
5. Open a pull request with a description of your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For questions or feedback, please contact [MunirchowdhurySaif](https://github.com/chowdhuryMunir).
