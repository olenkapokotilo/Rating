USE [master]
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
ON UPDATE CASCADE
ON DELETE CASCADE
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
ADD RatingTypeId INT NOT NULL
GO

ALTER TABLE [ActionType]
ADD CONSTRAINT FK_ActionType_RatingType
FOREIGN KEY (RatingTypeId)
REFERENCES RatingType(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/*------------------ADD ProjectId in RatingType--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [RatingType]
ADD ProjectId INT NOT NULL
GO
ALTER TABLE [RatingType]
ADD CONSTRAINT FK_RatingType_Project
FOREIGN KEY (ProjectId)
REFERENCES Project(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

/*------------------ADD table ProjectUser--------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[ProjectUser]    Script Date: 02.04.2015 13:22:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProjectUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ProjectUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/*------------------ADD table Rating --------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[Rating]    Script Date: 02.04.2015 13:24:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Score] [int] NOT NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/*------------------ADD  table Action--------------------------------------*/
USE [Rating]
GO

/****** Object:  Table [dbo].[Action]    Script Date: 02.04.2015 13:26:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Action](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Action] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/*------------------ADD foreign key ProjectId in ProjectUser --------------------------------------*/
USE [Rating]
GO

ALTER TABLE [ProjectUser]
ADD ProjectId INT NULL
GO

ALTER TABLE [ProjectUser]
ADD CONSTRAINT FK_ProjectUser_Project
FOREIGN KEY (ProjectId)
REFERENCES Project(Id)
GO
/*------------------ADD ExternalId in ProjectUser --------------------------------------*/
USE [Rating]
DELETE FROM [ProjectUser]
ALTER TABLE [ProjectUser]
ADD ExternalId [nvarchar](128) NOT NULL
GO
/*------------------ADD UNIQUE INDEX - RatingType--------------------------------------*/
USE [Rating]

GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_RatingType_Name_ProjectId] ON [dbo].[RatingType]
(
	[Name] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
/*------------------ADD UNIQUE INDEX - ActionType--------------------------------------*/
USE [Rating]
GO

CREATE UNIQUE NONCLUSTERED INDEX [UX_ActionType_Name_RatingTypeId] ON [dbo].[ActionType]
(
	[Name] ASC,
	[RatingTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


/*------------------ADD unique index Project--------------------------------------*/
USE [Rating]
GO

/****** Object:  Index [UX_Project_Name_UserId]    Script Date: 02.04.2015 14:30:12 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UX_Project_Name_UserId] ON [dbo].[Project]
(
	[Name] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/*------------------ADD  RatingRypeId in rating--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [Rating]
ADD RatingTypeId INT NOT NULL
GO

ALTER TABLE [Rating]
ADD CONSTRAINT FK_Rating_RatingType
FOREIGN KEY (RatingTypeId)
REFERENCES RatingType(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/*------------------ADD  projectUserId in Rating--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [Rating]
ADD ProjectUserId INT NULL
GO

ALTER TABLE [Rating]
ADD CONSTRAINT FK_Rating_ProjectUser
FOREIGN KEY (ProjectUserId)
REFERENCES ProjectUser(Id)
GO
/*------------------ADD actionTypeId in Action--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [Action]
ADD ActionTypeId INT NOT NULL
GO

ALTER TABLE [Action]
ADD CONSTRAINT FK_Action_ActionType
FOREIGN KEY (ActionTypeId)
REFERENCES ActionType(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/*------------------ProjectUserId in Action--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [Action]
ADD ProjectUserId INT NOT NULL
GO

ALTER TABLE [Action]
ADD CONSTRAINT FK_Action_ProjectUsere
FOREIGN KEY (ProjectUserId)
REFERENCES ProjectUser(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO
/*------------------RatingId in Action--------------------------------------*/
USE [Rating]
GO
ALTER TABLE [Action]
ADD RatingId INT NULL
GO

ALTER TABLE [Action]
ADD CONSTRAINT FK_Action_Rating
FOREIGN KEY (RatingId)
REFERENCES Rating(Id)
GO
/*------------------ADD --------------------------------------*/
/*------------------ADD --------------------------------------*/
/*------------------ADD --------------------------------------*/
/*------------------ADD --------------------------------------*/
/*------------------ADD --------------------------------------*/