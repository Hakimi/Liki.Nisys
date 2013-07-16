USE [master]
GO

create database LikiDB
Go

USE [LikiDB]
GO
 
/****** Object:  Table [dbo].[Customer]    Script Date: 07/15/2013 22:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Users(

      UserID int IDENTITY(1,1) NOT NULL,

      UserFID varchar(15) NOT NULL,

      EmailAddress varchar(100) NOT NULL,

      Title varchar(15) NULL,

      FirstName varchar(50) NOT NULL,

      MiddleName varchar(50) NULL,

      LastName varchar(50) NULL,

      Suffix varchar(15) NULL,

      Password varchar(200) NOT NULL,

      MobileNo varchar(15) NULL,

      SSN char(9) NULL,

      DateOfBirth date NULL,

      RoleID int NOT NULL DEFAULT(0),

CONSTRAINT User_PK PRIMARY KEY CLUSTERED ( UserID ASC ) )

GO
SET ANSI_PADDING OFF
GO
