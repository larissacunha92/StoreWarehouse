USE master;
GO

IF NOT EXISTS (
    SELECT name
    FROM sys.databases
    WHERE name = 'DemoDB'
)
CREATE DATABASE DemoDB;