# LibraryApi - Online Library Management System

 web application built with **ASP.NET Core 9** 

## Features
- JWT-based user authentication
- Category & book management
- Complete CRUD operations for books
- Shopping cart & order system
- Ability to delete orders
- Order count badge (visible only when logged in)
- Beautiful Glassmorphism design with teal-green gradient theme
- Production-ready (Swagger completely removed)
- Fully responsive on all devices

## Technologies
- ASP.NET Core 9.0
- Entity Framework Core 9 (Code-First)
- Razor Pages + Bootstrap 5 + Font Awesome
- JWT Bearer Authentication
- SQL Server

## How to Run

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQL Server (LocalDB or Express)

### Steps
```bash
# 1. Clone the repository
git clone https://github.com/OmidKianpoor/LibraryApi.git
cd LibraryApi

# 2. Restore packages
dotnet restore

# 3. Apply migrations & create database
dotnet ef database update

# 4. Run the application
dotnet run
