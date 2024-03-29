USE [master]
GO
/****** Object:  Database [sampleweb]    Script Date: 10/30/2013 19:12:44 ******/
CREATE DATABASE [sampleweb] ON  PRIMARY 
( NAME = N'sampleweb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\sampleweb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sampleweb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\sampleweb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sampleweb] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sampleweb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sampleweb] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [sampleweb] SET ANSI_NULLS OFF
GO
ALTER DATABASE [sampleweb] SET ANSI_PADDING OFF
GO
ALTER DATABASE [sampleweb] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [sampleweb] SET ARITHABORT OFF
GO
ALTER DATABASE [sampleweb] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [sampleweb] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [sampleweb] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [sampleweb] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [sampleweb] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [sampleweb] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [sampleweb] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [sampleweb] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [sampleweb] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [sampleweb] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [sampleweb] SET  DISABLE_BROKER
GO
ALTER DATABASE [sampleweb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [sampleweb] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [sampleweb] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [sampleweb] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [sampleweb] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [sampleweb] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [sampleweb] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [sampleweb] SET  READ_WRITE
GO
ALTER DATABASE [sampleweb] SET RECOVERY SIMPLE
GO
ALTER DATABASE [sampleweb] SET  MULTI_USER
GO
ALTER DATABASE [sampleweb] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [sampleweb] SET DB_CHAINING OFF
GO
USE [sampleweb]
GO
/****** Object:  Table [dbo].[BNameList]    Script Date: 10/30/2013 19:12:55 ******/
DROP TABLE [dbo].[BNameList]
GO
/****** Object:  Table [dbo].[CnameList]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[CnameList]
GO
/****** Object:  Table [dbo].[PAttribute]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[PAttribute]
GO
/****** Object:  Table [dbo].[PEANs]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[PEANs]
GO
/****** Object:  Table [dbo].[PManufacturerPartNumber]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[PManufacturerPartNumber]
GO
/****** Object:  Table [dbo].[PModelNumber]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[PModelNumber]
GO
/****** Object:  Table [dbo].[PNameList]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[PNameList]
GO
/****** Object:  Table [dbo].[PUPCs]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[PUPCs]
GO
/****** Object:  Table [dbo].[tblBrands]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[tblBrands]
GO
/****** Object:  Table [dbo].[tblCategory]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[tblCategory]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[tblProduct]
GO
/****** Object:  Table [dbo].[tblXmlGen]    Script Date: 10/30/2013 19:12:48 ******/
DROP TABLE [dbo].[tblXmlGen]
GO
/****** Object:  User [dbadmin]    Script Date: 10/30/2013 19:12:44 ******/
DROP USER [dbadmin]
GO
/****** Object:  User [dbadmin]    Script Date: 10/30/2013 19:12:44 ******/
CREATE USER [dbadmin] FOR LOGIN [dbadmin] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[tblXmlGen]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblXmlGen](
	[xmltables] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblXmlGen] ([xmltables]) VALUES (N'tblBrands')
INSERT [dbo].[tblXmlGen] ([xmltables]) VALUES (N'tblCategory')
INSERT [dbo].[tblXmlGen] ([xmltables]) VALUES (N'tblProduct')
/****** Object:  Table [dbo].[tblProduct]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblProduct](
	[ProductId] [varchar](50) NULL,
	[CategoryId] [varchar](50) NULL,
	[BrandId] [varchar](50) NULL,
	[ProductName] [varchar](250) NULL,
	[Description] [varchar](250) NULL,
	[PpgUrl] [varchar](500) NULL,
	[Pimgurl] [varchar](500) NULL,
	[PnameId] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblProduct] ([ProductId], [CategoryId], [BrandId], [ProductName], [Description], [PpgUrl], [Pimgurl], [PnameId]) VALUES (N'1', N'1', NULL, N'Pain Gel', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ProductId], [CategoryId], [BrandId], [ProductName], [Description], [PpgUrl], [Pimgurl], [PnameId]) VALUES (N'2', N'1', NULL, N'Shower Gel', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ProductId], [CategoryId], [BrandId], [ProductName], [Description], [PpgUrl], [Pimgurl], [PnameId]) VALUES (N'3', N'2', NULL, N'Fever Tablet', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ProductId], [CategoryId], [BrandId], [ProductName], [Description], [PpgUrl], [Pimgurl], [PnameId]) VALUES (N'4', N'2', NULL, N'Calcium Tablet', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ProductId], [CategoryId], [BrandId], [ProductName], [Description], [PpgUrl], [Pimgurl], [PnameId]) VALUES (N'5', N'3', NULL, N'Iron Tonic', NULL, NULL, NULL, NULL)
INSERT [dbo].[tblProduct] ([ProductId], [CategoryId], [BrandId], [ProductName], [Description], [PpgUrl], [Pimgurl], [PnameId]) VALUES (N'6', N'3', NULL, N'Cough tonic', NULL, NULL, NULL, NULL)
/****** Object:  Table [dbo].[tblCategory]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblCategory](
	[BrandId] [varchar](50) NULL,
	[CategoryId] [varchar](50) NULL,
	[CategoryName] [varchar](250) NULL,
	[CpgUrl] [varchar](500) NULL,
	[CimgUrl] [varchar](500) NULL,
	[CnameId] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblCategory] ([BrandId], [CategoryId], [CategoryName], [CpgUrl], [CimgUrl], [CnameId]) VALUES (N'1', N'1', N'Gel', N'http://www.example.com/category.htm?cat=1010', N'http://images.example.com/en_us/catimages/1010.gif', N'1')
INSERT [dbo].[tblCategory] ([BrandId], [CategoryId], [CategoryName], [CpgUrl], [CimgUrl], [CnameId]) VALUES (N'1', N'2', N'Tablet', N'http://www.example.com/category.htm?cat=1010', N'http://images.example.com/en_us/catimages/1010.gif', N'2')
INSERT [dbo].[tblCategory] ([BrandId], [CategoryId], [CategoryName], [CpgUrl], [CimgUrl], [CnameId]) VALUES (N'2', N'3', N'Tonic', N'http://www.example.com/category.htm?cat=1010', N'http://images.example.com/en_us/catimages/1010.gif', N'3')
/****** Object:  Table [dbo].[tblBrands]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tblBrands](
	[BrandId] [varchar](50) NULL,
	[BrandName] [varchar](250) NULL,
	[BnameID] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tblBrands] ([BrandId], [BrandName], [BnameID]) VALUES (N'1', N'First Class', N'1')
INSERT [dbo].[tblBrands] ([BrandId], [BrandName], [BnameID]) VALUES (N'2', N'Second Class', N'2')
INSERT [dbo].[tblBrands] ([BrandId], [BrandName], [BnameID]) VALUES (N'3', N'Third Class', N'3')
/****** Object:  Table [dbo].[PUPCs]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PUPCs](
	[PnameId] [varchar](50) NULL,
	[PUPCs] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PNameList]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PNameList](
	[PnameId] [varchar](50) NULL,
	[PLocale] [varchar](250) NULL,
	[PLname] [varchar](250) NULL,
	[PLdesc] [varchar](500) NULL,
	[PLpgUrl] [varchar](500) NULL,
	[PLimgUrl] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PModelNumber]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PModelNumber](
	[PnameId] [varchar](50) NULL,
	[PModel] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PManufacturerPartNumber]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PManufacturerPartNumber](
	[PnameId] [varchar](50) NULL,
	[PManufacturer] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PEANs]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PEANs](
	[PnameId] [varchar](50) NULL,
	[EANs] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PAttribute]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PAttribute](
	[PnameId] [varchar](50) NULL,
	[PattributeId] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CnameList]    Script Date: 10/30/2013 19:12:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CnameList](
	[CnameId] [varchar](50) NULL,
	[CLocale] [varchar](250) NULL,
	[CLname] [varchar](250) NULL,
	[CLpgUrl] [varchar](500) NULL,
	[CLimgUrl] [varchar](500) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CnameList] ([CnameId], [CLocale], [CLname], [CLpgUrl], [CLimgUrl]) VALUES (N'1', N'en_US', N'First Category1', N'http://www.example.com/category.htm?cat=1010', N'http://images.example.com/catimages/1010.gif')
INSERT [dbo].[CnameList] ([CnameId], [CLocale], [CLname], [CLpgUrl], [CLimgUrl]) VALUES (N'1', N'en_CA', N'First Category2', N'http://www.example.com/category.htm?cat=1010', N'http://images.example.com/catimages/1010.gif')
INSERT [dbo].[CnameList] ([CnameId], [CLocale], [CLname], [CLpgUrl], [CLimgUrl]) VALUES (N'1', N'fr_CA', N'First Category3', N'http://www.example.com/category.htm?cat=1010', N'http://images.example.com/catimages/1010.gif')
/****** Object:  Table [dbo].[BNameList]    Script Date: 10/30/2013 19:12:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BNameList](
	[BNameId] [varchar](50) NULL,
	[BLocale] [varchar](50) NULL,
	[BLocalName] [varchar](250) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[BNameList] ([BNameId], [BLocale], [BLocalName]) VALUES (N'1', N'en_US', N'First Brand1')
INSERT [dbo].[BNameList] ([BNameId], [BLocale], [BLocalName]) VALUES (N'1', N'en_CA', N'First Brand2')
INSERT [dbo].[BNameList] ([BNameId], [BLocale], [BLocalName]) VALUES (N'1', N'fr_CA', N'First Brand3')
