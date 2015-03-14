﻿USE [master]
GO

/****** Object:  Database [Rating]    Script Date: 10.02.2015 23:57:12 ******/
CREATE DATABASE [Rating]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Rating', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Rating.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Rating_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Rating_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Rating] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Rating].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Rating] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Rating] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Rating] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Rating] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Rating] SET ARITHABORT OFF 
GO

ALTER DATABASE [Rating] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Rating] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Rating] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Rating] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Rating] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Rating] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Rating] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Rating] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Rating] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Rating] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Rating] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Rating] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Rating] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Rating] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Rating] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Rating] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Rating] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Rating] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Rating] SET RECOVERY FULL 
GO

ALTER DATABASE [Rating] SET  MULTI_USER 
GO

ALTER DATABASE [Rating] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Rating] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Rating] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Rating] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Rating] SET  READ_WRITE 
GO




/*--------------------------------------------------------*/
/*--------------------------------------------------------*/
/*-------------------TABLES-------------------------------*/
/*--------------------------------------------------------*/
/*--------------------------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[User]    Script Date: 10.02.2015 23:58:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*--------------------------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[Project]    Script Date: 11.02.2015 0:05:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_User]
GO

/*--------------------------CREATE TABLE ROLE------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[Role]    Script Date: 12.02.2015 20:11:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/*------------------ADD RoleId TO User--------------------------------------*/
USE [Rating]
GO

ALTER TABLE [User]
ADD RoleId INT DEFAULT(1)
GO

ALTER TABLE [User]
ADD CONSTRAINT FK_User_Role
FOREIGN KEY (RoleId)
REFERENCES Role(Id)
GO

UPDATE [User] SET [RoleId]=1 WHERE [RoleId] IS NULL
GO

ALTER TABLE [User]
ALTER COLUMN [RoleId] INT NOT NULL
GO


/*------------------ADD Phone TO User--------------------------------------*/
USE [Rating]
GO

ALTER TABLE [User]
ADD Phone varchar(15) DEFAULT '000-000-0000'
GO

UPDATE [User] 
SET [Phone]= '000-000-0000' 
WHERE [Phone] IS NULL
GO
ALTER TABLE [User]
ALTER COLUMN [Phone] INT NOT NULL
GO


/*------------------ADD TABLE RatingType--------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[RatingType]    Script Date: 10.03.2015 15:52:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RatingType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RatingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/*------------------ADD TABLE ActionType--------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[ActionType]    Script Date: 10.03.2015 15:58:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActionType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Scores] [int] NOT NULL,
 CONSTRAINT [PK_ActionType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*------------------ADD RatingTypeId TO ActionType--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [ActionType]
ADD RatingTypeId INT DEFAULT(1)
GO
ALTER TABLE [ActionType]
ADD CONSTRAINT FK_RatingType_ActionType
FOREIGN KEY (RatingTypeId)
REFERENCES RatingType(Id)
GO
UPDATE [ActionType] SET [RatingTypeId] =1 WHERE [RatingTypeId] IS NULL
GO
ALTER TABLE [ActionType]
ALTER COLUMN [RatingTypeId] INT NOT NULL
GO
/*------------------ADD ProjectId in RatingType--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [RatingType]
ADD ProjectId INT DEFAULT(1)
GO
ALTER TABLE [RatingType]
ADD CONSTRAINT FK_Project_RatingType
FOREIGN KEY (ProjectId)
REFERENCES Project(Id)
GO
UPDATE [RatingType] SET [ProjectId] =1 WHERE [ProjectId] IS NULL
GO
ALTER TABLE [RatingType]
ALTER COLUMN [ProjectId] INT NOT NULL
GO
/*------------------ADD ProjectId in RatingType--------------------------------------*/


