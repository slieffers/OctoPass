USE [master]
GO
/****** Object:  Database [OctoPass]    Script Date: 2/25/2019 2:29:52 PM ******/
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'OctoPass')
BEGIN
CREATE DATABASE [OctoPass]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OctoPass', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OctoPass.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OctoPass_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\OctoPass_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
END
GO
ALTER DATABASE [OctoPass] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OctoPass].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OctoPass] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OctoPass] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OctoPass] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OctoPass] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OctoPass] SET ARITHABORT OFF 
GO
ALTER DATABASE [OctoPass] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OctoPass] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OctoPass] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OctoPass] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OctoPass] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OctoPass] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OctoPass] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OctoPass] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OctoPass] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OctoPass] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OctoPass] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OctoPass] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OctoPass] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OctoPass] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OctoPass] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OctoPass] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OctoPass] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OctoPass] SET RECOVERY FULL 
GO
ALTER DATABASE [OctoPass] SET  MULTI_USER 
GO
ALTER DATABASE [OctoPass] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OctoPass] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OctoPass] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OctoPass] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OctoPass] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'OctoPass', N'ON'
GO
ALTER DATABASE [OctoPass] SET QUERY_STORE = OFF
GO
USE [OctoPass]
GO
/****** Object:  Table [dbo].[WeatherCondition]    Script Date: 2/25/2019 2:29:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WeatherCondition]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WeatherCondition](
	[WeatherConditionId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NOT NULL
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[WeatherCondition] ON 

INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (1, N'Freezing')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (2, N'Bracing')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (3, N'Chilly')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (4, N'Cool')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (5, N'Mild')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (6, N'Warm')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (7, N'Balmy')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (8, N'Hot')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (9, N'Sweltering')
INSERT [dbo].[WeatherCondition] ([WeatherConditionId], [Description]) VALUES (10, N'Scorching')
SET IDENTITY_INSERT [dbo].[WeatherCondition] OFF
/****** Object:  Index [WeatherCondition_pk]    Script Date: 2/25/2019 2:29:53 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WeatherCondition]') AND name = N'WeatherCondition_pk')
ALTER TABLE [dbo].[WeatherCondition] ADD  CONSTRAINT [WeatherCondition_pk] PRIMARY KEY NONCLUSTERED 
(
	[WeatherConditionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [WeatherCondition_Description_uindex]    Script Date: 2/25/2019 2:29:53 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WeatherCondition]') AND name = N'WeatherCondition_Description_uindex')
CREATE UNIQUE NONCLUSTERED INDEX [WeatherCondition_Description_uindex] ON [dbo].[WeatherCondition]
(
	[Description] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [WeatherCondition_WeatherConditionId_uindex]    Script Date: 2/25/2019 2:29:53 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WeatherCondition]') AND name = N'WeatherCondition_WeatherConditionId_uindex')
CREATE UNIQUE NONCLUSTERED INDEX [WeatherCondition_WeatherConditionId_uindex] ON [dbo].[WeatherCondition]
(
	[WeatherConditionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [OctoPass] SET  READ_WRITE 
GO
