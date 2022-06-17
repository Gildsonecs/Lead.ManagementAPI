IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LeadManagementDB')
BEGIN
  CREATE DATABASE LeadManagementDB;
END;
GO

USE [LeadManagementDB]
GO

/** Object:  Table [dbo].[Contacts]    Script Date: 03/06/2022 10:39:02 **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [dbo].[Contacts](
	Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
	FirstName varchar(100) NOT NULL,
	FullName varchar(100),
	PhoneNumber varchar(11),
	Email varchar(100),	
	Suburb varchar(100),
	Category varchar(100),
	Description varchar(500),
	Price float,
	Accept Bit,
	DateCreated DateTime default GETDATE() NOT NULL
);