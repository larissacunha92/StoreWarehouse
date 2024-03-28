StoreWarehouse.API
=====================

## How to use:
- You will need the Visual Studio 2022 and the latest .NET Core SDK.
- Docker
- SQL Server Management Studio
- Connect to SQL Server Database using localhost, 8002, sa, Docker#1234
- Run script to create the DB (from scripts folder)
```sql
USE master;
GO

IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = 'DemoDB'
)
CREATE DATABASE DemoDB;
```

- Open Visual Studio Solution then go to ```View -> Other Windows -> Package Manager Console``` and run ```Update-Database```
- Run visual studio app
  
- enviar request pelo swagger

## Technologies implemented:

- ASP .NET 6.0
- - Entity Framework
  - - Swagger UI
    - rABBITmq
   - .NET Native DI
    

## Architecture:
- Repository Patterns
- Producer and Consumer Patterns
- Extension Method
- Responsibility separation concerns
- SOLID and Clean Code

- [architecture draw]
