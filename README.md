**Employee Management System**

---

### Overview

The Employee Management System is a basic CRUD (Create, Read, Update, Delete) application developed as a demonstration to learn the fundamental concepts of building web applications. This system allows users to perform operations such as adding, viewing, updating, and deleting employee records.

### Features

- **CRUD Operations**: Users can create, read, update, and delete employee records.
  
- **Dropdown List Population**: The system includes functionality to populate dropdown lists dynamically from a database using AJAX calls. This feature is specifically implemented for selecting the city and district of an employee.

### Technologies Used

- **Frontend**:
  - HTML
  - CSS
  - JavaScript (jQuery)
  
- **Backend**:
  - C# (.NET Core)
  - ASP.NET MVC
  
- **Database**:
  - SQL Server

### Installation

1. Clone the repository to your local machine.
   ```
   git clone https://github.com/your_username/employee-management-system.git
   ```

2. Open the project in your preferred IDE (Integrated Development Environment).

3. Set up the database:
   - Ensure you have SQL Server installed.
   - Execute the SQL script provided in the `database` folder to create the required tables.

4. Configure the database connection string:
   - Locate the connection string in the project's configuration file (`appsettings.json` or `web.config`) and update it with your SQL Server credentials.

5. Build and run the project.

### Usage

- Upon running the application, you will be directed to the homepage displaying a list of employees.
- Use the navigation links to perform CRUD operations and manage employee records.
- To select the city and district of an employee, use the dropdown lists provided on the respective form.

### Folder Structure

```
employee-management-system/
│
├── Controllers/
│   └── EmployeeController.cs
│
├── Models/
│   └── City.cs
│   └── District.cs
│   └── Employee.cs
│
├── Repositories/
│   └── EmployeeRepository.cs
│   └── IEmployeeRepository.cs
│
├── Views/
│   ├── Dropdown/
│   │   ├── District.cshtml
│   │   ├── City.cshtml
│   ├── Employee/
│   │   ├── Create.cshtml
│   │   ├── Delete.cshtml
│   │   ├── Edit.cshtml
│   │   └── Index.cshtml
│   ├── Shared/
│   │   └── _Layout.cshtml
│   └── ...
│
└── wwwroot/
    ├── css/
    │   └── styles.css
    ├── js/
    │   └── site.js
    └── ...
```

### Credits

This project was created as part of a learning process and is inspired by various tutorials and resources available online.

### License

This project is demo project created to learn basic CRUD and Ajax call.
  
--- 

Feel free to expand and enhance this README file as needed. Enjoy learning and building with the Employee Management System!
