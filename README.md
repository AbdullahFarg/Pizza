# 🍕 Pizza API

![.NET](https://img.shields.io/badge/.NET-6.0-blue) ![License](https://img.shields.io/badge/license-MIT-green) ![Contributions](https://img.shields.io/badge/contributions-welcome-orange) ![Issues](https://img.shields.io/github/issues/AbdullahFarg/pizza) ![Forks](https://img.shields.io/github/forks/AbdullahFarg/pizza) ![Stars](https://img.shields.io/github/stars/AbdullahFarg/pizza)

## 📖 Introduction
Welcome to the **Pizza API**! This project is a robust and scalable backend solution for managing pizza orders, users, and more. Built with .NET 6.0, it leverages modern web development practices to deliver a seamless experience for developers and end-users alike.

## ✨ Features
- **User Management**: CRUD operations for users with role-based authorization.
- **Pizza Management**: Add, update, delete, and filter pizzas by price or name.
- **Order Management**: Create, update, and track orders with detailed statuses.
- **JWT Authentication**: Secure API endpoints with JSON Web Tokens.
- **Swagger Integration**: Explore and test API endpoints interactively.

## 🗂️ Project Structure
```
Pizza/
├── Pizza.sln             # Solution file
├── README.md              # Project documentation
├── Pizza.CORE/            # Core business logic and models
│   ├── Pizza.CORE.csproj  # Core project file
│   ├── DTOs/              # Data Transfer Objects
│   ├── Interfaces/        # Interfaces for abstraction
│   ├── JWT/               # JWT-related utilities
│   ├── Models/            # Domain models
│   └── obj/               # Build artifacts
├── Pizza.EF/              # Entity Framework and database layer
│   ├── Pizza.EF.csproj    # EF project file
│   ├── AppDbContext/      # Database context
│   ├── Migrations/        # Database migrations
│   ├── Services/          # Data services
│   └── obj/               # Build artifacts
└── Pizza.API/            # API project
    ├── Pizza.API.csproj  # API project file
    ├── appsettings.json   # Configuration file
    ├── appsettings.Development.json # Development configuration
    ├── Program.cs         # Entry point of the application
    ├── Controllers/       # API controllers
    ├── Properties/        # Project properties
    └── obj/               # Build artifacts
```

## 🛠️ Installation
1. **Clone the repository**:
   ```bash
   git clone https://github.com/AbdullahFarg/Pizza.git
   cd pizza
   ```
2. **Set up the database**:
   - Update the connection string in `appsettings.json` under `Pizza.API`.
   - Run migrations:
     ```bash
     dotnet ef database update --project Pizza.EF
     ```
3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```
4. **Build the solution**:
   ```bash
   dotnet build
   ```

## 🚀 Usage
1. **Run the API**:
   ```bash
   dotnet run --project Pizza.API
   ```
2. **Access Swagger UI**:
   Navigate to `http://localhost:5062/swagger` to explore and test the API endpoints.
3. **Test Endpoints**:
   Use the provided `Pizza.API.http` file for quick API testing.

## 🤝 Contributing
We welcome contributions! To get started:
1. Fork the repository.
2. Create a new branch for your feature or bugfix.
3. Submit a pull request with a clear description of your changes.

## 📜 License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments
- Thanks to the .NET community for their amazing tools and resources.
- Special shoutout to all contributors who make this project better every day!
