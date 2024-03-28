StoreWarehouse.API
=====================

## How to use:

**Required tools**
- Visual Studio 2022 and the latest .NET Core SDK.
- Docker
- SQL Server Management Studio

**Run Instructions**
- Open SQL Server Management Studio and connect to SQL Server Database using the following set up:
    ```
    Server Type: Database Engine
    Server name: localhost, 8002
    Authentication: SQL Server Authentication
    Login: sa
    Password: Docker#1234
    ```
- Then run the script to create the database
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
- Open the StoreWarehouse solution in Visual Studio then go to ```View -> Other Windows -> Package Manager Console``` and run ```Update-Database```
- Then run StoreWareHouse.API
- Send the request through Swagger

**See output result**

- In SQL Server Management Database, run the query below to see the requests inserted in the database
    ```sql
    USE [DemoDB]
    GO
    SELECT [Id]
        ,[ProductId]
        ,[Quantity]
        ,[SourceWarehouseId]
        ,[TargetWarehouseId]
        ,[Status]
        ,[Date]
    FROM [dbo].[ProductTrack]
    GO
    ```
  - To see the requests published by the producer, access ```http://localhost:15672/```

## Technologies implemented:

- ASP .NET 6.0
- Entity Framework
- Swagger UI
- RabbitMQ
- .NET Native DI

## Architecture:
- Repository Patterns
- Producer and Consumer Patterns
- Extension Method
- Responsibility separation concerns
- SOLID and Clean Code

[![JjvQ9TJ.md.png](https://iili.io/JjvQ9TJ.md.png)](https://freeimage.host/i/JjvQ9TJ)