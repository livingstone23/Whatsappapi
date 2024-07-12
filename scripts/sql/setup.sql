CREATE DATABASE ACDDatabase
GO

USE ACDDatabase
GO

CREATE TABLE BalanceServiceProvider
(
	Id INT IDENTITY(1,1) PRIMARY KEY,
    BusinessId NVARCHAR(128) NOT NULL,
    BspCode NVARCHAR(128) NOT NULL,
    BspName NVARCHAR(128) NOT NULL,
    CodingScheme NVARCHAR(128) NOT NULL,
    Country NVARCHAR(128) NOT NULL,
	ValidityStart datetime not null,
	ValidityEnd datetime not null,
	Active bit NOT NULL,
    Created DATETIME,
    CreatedBy NVARCHAR(128),
    Updated DATETIME,
    UpdatedBy NVARCHAR(128)
);
GO
