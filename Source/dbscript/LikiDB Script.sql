USE [master]
GO

create database LikiDB
Go

 
/****** Object:  Table [dbo].[Customer]    Script Date: 07/15/2013 22:28:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[EmailAddress] [varchar](70) NOT NULL,
	[Title] [varchar](20) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[MiddleName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Suffix] [varchar](10) NOT NULL,
	[Password] [varchar](200) NOT NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [Customer_PK] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
