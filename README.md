Student Management System API
Simple ASP.NET Core Web API for managing students with JWT authentication.

Features
CRUD Operations: Get all, Get by ID, Add, Update, Delete students
JWT Authentication: Secure endpoints with token-based auth
SQL Server Database: Entity Framework Core integration
Layered Architecture: Controller → Service → Repository → DbContext
Global Exception Handling: Custom middleware for error handling
Logging: Built-in ASP.NET Core logging
Swagger Documentation: Interactive API testing
Quick Start
1. Run the Application
cd StudentManagementSystem
dotnet restore
dotnet run
2. Access Swagger UI
Open browser: https://localhost:7000

3. Login to Get JWT Token
POST /api/auth/login

{
  "username": "admin",
  "password": "admin123"
}
4. Use Token for Protected Endpoints
Click "Authorize" in Swagger → Enter: Bearer {your-token}

API Endpoints
Authentication
POST /api/auth/login - Get JWT token
Students (Protected)
GET /api/students - Get all students
GET /api/students/{id} - Get student by ID
POST /api/students - Create new student
PUT /api/students/{id} - Update student
DELETE /api/students/{id} - Delete student
Project Structure
├── Controllers/          # API endpoints
├── Services/            # Business logic
├── Repositories/        # Data access
├── Models/             # Data models
├── Data/               # DbContext
├── Middleware/         # Exception handling
└── Program.cs          # App configuration
Database Schema
Students Table:

Id (Primary Key)
Name (Required)
Email (Required)
Age
Course (Required)
CreatedDate
Key Technologies
ASP.NET Core 8.0

Entity Framework Core

JWT Authentication

SQL Server

Swagger/OpenAPI

Interface-based abstractions

Default Credentials
Username: admin
Password: admin123
