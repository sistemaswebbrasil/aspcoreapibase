# Asp .net core

Base API using ASP.NET CORE and Mysql

## common command reminders

Project Creation

```bash
dotnet new webapi -o TodoApi
```

Add suport Mysql with Pomelo Package

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Pomelo.EntityFrameworkCore.MySql.Design
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

Creating migration file after created entity

```bash
dotnet ef migrations add UserMigration
```

Updates the database according to created migrations

```bash
dotnet ef database update
```
