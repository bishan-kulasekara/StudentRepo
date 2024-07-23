# Student Registration System

## Overview

This project is a simple web application for managing student registrations, built using C#.Net and Angular 14. It features a summary and detail sections, a full-width grid for student details, CRUD operations, pagination, searching, sorting, and profile image display.

## Technologies Used

- C#.Net
- Angular 17.3.11
- Entity Framework Core
- MS SQL Server Express
- Visual Studio / Visual Studio Code

## Features

- Summary/Detail sections for student information
- Full-width grid for student details
- Select/Click on a student to populate the details section
- Click again to hide the details section
- CRUD operations (Insert, Update, Delete)
- Pagination, Searching, Sorting
- Display of profile image

## Requirements

- .NET SDK
- Node.js
- Angular CLI
- MS SQL Server Express

## Setup Instructions

1. **Clone the Repository**
   ```
   git clone [GitHub Repository URL]
   cd student-registration-system
   ```
2. **Backend Setup**
    Open the solution in Visual Studio.
    Update the connection string in appsettings.json to match your SQL Server instance.
    Run the following command in the Package Manager Console to set up the database:
    ```
    Update-Database
    ```
3. **Frontend Setup**
    Navigate to the ClientApp directory.
    Install the necessary npm packages:
    ```
    cd ClientApp
    npm install
    ```

