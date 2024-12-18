USE [master]
GO
/****** Object:  Database [AracKiralama]    Script Date: 29.11.2024 11:38:58 ******/
CREATE DATABASE [AracKiralama]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AracKiralama', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AracKiralama.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AracKiralama_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AracKiralama_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AracKiralama] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AracKiralama].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AracKiralama] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AracKiralama] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AracKiralama] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AracKiralama] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AracKiralama] SET ARITHABORT OFF 
GO
ALTER DATABASE [AracKiralama] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AracKiralama] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AracKiralama] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AracKiralama] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AracKiralama] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AracKiralama] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AracKiralama] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AracKiralama] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AracKiralama] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AracKiralama] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AracKiralama] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AracKiralama] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AracKiralama] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AracKiralama] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AracKiralama] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AracKiralama] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AracKiralama] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AracKiralama] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AracKiralama] SET  MULTI_USER 
GO
ALTER DATABASE [AracKiralama] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AracKiralama] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AracKiralama] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AracKiralama] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AracKiralama] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AracKiralama] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AracKiralama] SET QUERY_STORE = OFF
GO
USE [AracKiralama]
GO
/****** Object:  Table [dbo].[Birim]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Birim](
	[Id] [int] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Birim] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTable]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogTable](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[UserId] [int] NOT NULL,
	[RequestPath] [nvarchar](2500) NULL,
	[RequestBody] [nvarchar](max) NULL,
	[ApplicationId] [tinyint] NOT NULL,
	[ResponseBody] [nvarchar](max) NULL,
	[LogMessage] [nvarchar](2500) NULL,
	[ErrorCode] [int] NULL,
	[IpAddress] [varchar](50) NULL,
	[ProcessTime] [bigint] NOT NULL,
	[LastTransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LogTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Market]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Market](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Ad] [nvarchar](50) NULL,
	[Adres] [nvarchar](500) NULL,
	[Puan] [decimal](6, 2) NULL,
	[LastTransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Market] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MarketUrun]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MarketUrun](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[MarketId] [int] NULL,
	[UrunId] [int] NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[Stok] [decimal](8, 2) NULL,
	[Puan] [decimal](6, 2) NULL,
	[LastTransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_MaketUrun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiktarTur]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiktarTur](
	[Id] [int] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MiktarTur] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Model]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Model](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BrandId] [smallint] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Model] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personel]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personel](
	[Id] [int] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[Soyad] [nvarchar](50) NOT NULL,
	[UnvanId] [int] NOT NULL,
	[BirimId] [int] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Personel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonelSepet]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelSepet](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[PersonelId] [int] NOT NULL,
	[LastTransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonelSepet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonelSepetUrun]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelSepetUrun](
	[Id] [uniqueidentifier] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[PersonelSepetId] [uniqueidentifier] NOT NULL,
	[UrunId] [int] NOT NULL,
	[Miktar] [decimal](18, 2) NOT NULL,
	[Tutar] [decimal](18, 2) NOT NULL,
	[LastTransactionDate] [datetime] NOT NULL,
 CONSTRAINT [PK_PersonelSepetUrun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unvan]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unvan](
	[Id] [int] NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Unvan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Urun]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[Ad] [nvarchar](50) NOT NULL,
	[MiktarTurId] [int] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Urun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[EPosta] [nvarchar](150) NOT NULL,
	[Phone] [nvarchar](11) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicle]    Script Date: 29.11.2024 11:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Plate] [nvarchar](50) NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Year] [int] NOT NULL,
	[FuelType] [nvarchar](50) NOT NULL,
	[BrandId] [smallint] NOT NULL,
	[ModelId] [smallint] NOT NULL,
	[DailyPrice] [decimal](18, 2) NOT NULL,
	[StatusId] [tinyint] NOT NULL,
	[LastTransactionDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Birim] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (1, 1, N'Bilgi teknolojileri Daire Başkanlığı', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (1, N'Ford', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brand] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (2, N'Honda', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Brand] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (3, N'Hundai', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[LogTable] ON 

INSERT [dbo].[LogTable] ([Id], [StatusId], [UserId], [RequestPath], [RequestBody], [ApplicationId], [ResponseBody], [LogMessage], [ErrorCode], [IpAddress], [ProcessTime], [LastTransactionDate]) VALUES (5, 1, 0, N'/api/Auth/login', N'{
  "ePosta": "string",
  "password": "string"
}', 1, N'{"data":null,"isSuccess":false,"message":"EPosta veya paralo yanlış"}', NULL, NULL, N'::1', 0, CAST(N'2024-11-13T11:54:04.567' AS DateTime))
INSERT [dbo].[LogTable] ([Id], [StatusId], [UserId], [RequestPath], [RequestBody], [ApplicationId], [ResponseBody], [LogMessage], [ErrorCode], [IpAddress], [ProcessTime], [LastTransactionDate]) VALUES (9, 1, 0, N'/api/Auth/login', N'{
  "ePosta": "string",
  "password": "string"
}', 1, N'{"data":null,"isSuccess":false,"message":"EPosta veya paralo yanlış"}', NULL, NULL, N'::1', 0, CAST(N'2024-11-13T14:22:16.490' AS DateTime))
INSERT [dbo].[LogTable] ([Id], [StatusId], [UserId], [RequestPath], [RequestBody], [ApplicationId], [ResponseBody], [LogMessage], [ErrorCode], [IpAddress], [ProcessTime], [LastTransactionDate]) VALUES (10, 1, 0, N'/api/Vehicle/add', N'{
  "id": 0,
  "plate": "string",
  "color": "string",
  "year": 2023,
  "fuelType": "string",
  "brandId": 1,
  "modelId": 1,
  "dailyPrice": 1500
}', 1, N'{"data":{"id":6,"plate":"string","color":"string","year":2023,"fuelType":"string","brandId":1,"modelId":1,"dailyPrice":1500},"isSuccess":true,"message":null}', NULL, NULL, N'::1', 0, CAST(N'2024-11-13T14:22:56.337' AS DateTime))
SET IDENTITY_INSERT [dbo].[LogTable] OFF
GO
SET IDENTITY_INSERT [dbo].[Market] ON 

INSERT [dbo].[Market] ([Id], [StatusId], [Ad], [Adres], [Puan], [LastTransactionDate]) VALUES (1, 1, N'Güler Market', NULL, NULL, CAST(N'2024-11-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Market] OFF
GO
INSERT [dbo].[MarketUrun] ([Id], [StatusId], [MarketId], [UrunId], [Fiyat], [Stok], [Puan], [LastTransactionDate]) VALUES (N'0b39088b-988e-491c-80f9-c19f65419cb0', 1, 1, 1, CAST(15.00 AS Decimal(18, 2)), CAST(30.00 AS Decimal(8, 2)), CAST(0.00 AS Decimal(6, 2)), CAST(N'2024-11-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[MiktarTur] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (1, 1, N'KG', CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[MiktarTur] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (2, 1, N'Adet', CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Model] ON 

INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (1, N'CR-V', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (3, N'ZR-V', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (4, N'HR-V', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (5, N'CIVIC', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (6, N'JAZZ', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (7, N'CITY', 2, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (8, N'Yeni Kuga', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (10, N'Yeni Puma', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (11, N'Focus', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (12, N'Ford Mustang Mach E', 1, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (14, N'i10', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (15, N'i20', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (16, N'Elentra', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Model] ([Id], [Name], [BrandId], [StatusId], [LastTransactionDate]) VALUES (17, N'Yeni BAYON', 3, 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Model] OFF
GO
INSERT [dbo].[Personel] ([Id], [StatusId], [Ad], [Soyad], [UnvanId], [BirimId], [LastTransactionDate]) VALUES (1, 1, N'Mustafa', N'ÇAVDAROĞLU', 2, 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Personel] ([Id], [StatusId], [Ad], [Soyad], [UnvanId], [BirimId], [LastTransactionDate]) VALUES (2, 1, N'Ahmet', N'DOĞAN', 1, 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Personel] ([Id], [StatusId], [Ad], [Soyad], [UnvanId], [BirimId], [LastTransactionDate]) VALUES (3, 1, N'Ayşe', N'ÇAKIR', 2, 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
GO
INSERT [dbo].[PersonelSepet] ([Id], [StatusId], [PersonelId], [LastTransactionDate]) VALUES (N'1de30f9d-dc5c-4848-aa82-1f456aab4521', 1, 2, CAST(N'2024-11-28T11:18:46.550' AS DateTime))
INSERT [dbo].[PersonelSepet] ([Id], [StatusId], [PersonelId], [LastTransactionDate]) VALUES (N'1bcc5fbe-4548-4220-b103-3dc54935a443', 1, 3, CAST(N'2024-11-28T15:37:17.623' AS DateTime))
INSERT [dbo].[PersonelSepet] ([Id], [StatusId], [PersonelId], [LastTransactionDate]) VALUES (N'463f491b-d572-492b-b28e-9766e9efaf39', 1, 1, CAST(N'2024-11-27T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[PersonelSepetUrun] ([Id], [StatusId], [PersonelSepetId], [UrunId], [Miktar], [Tutar], [LastTransactionDate]) VALUES (N'7e96bc97-6982-e17d-bf76-074d68c61fd4', 1, N'463f491b-d572-492b-b28e-9766e9efaf39', 3, CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-11-28T14:29:45.447' AS DateTime))
INSERT [dbo].[PersonelSepetUrun] ([Id], [StatusId], [PersonelSepetId], [UrunId], [Miktar], [Tutar], [LastTransactionDate]) VALUES (N'10bc3368-ebc4-4dbf-b2cc-52a035034d33', 1, N'463f491b-d572-492b-b28e-9766e9efaf39', 1, CAST(1.00 AS Decimal(18, 2)), CAST(20.00 AS Decimal(18, 2)), CAST(N'2024-11-28T14:29:45.447' AS DateTime))
INSERT [dbo].[PersonelSepetUrun] ([Id], [StatusId], [PersonelSepetId], [UrunId], [Miktar], [Tutar], [LastTransactionDate]) VALUES (N'5f8fb080-420d-e8b2-ba61-70c48f9764e9', 1, N'1de30f9d-dc5c-4848-aa82-1f456aab4521', 3, CAST(5.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(N'2024-11-28T15:36:59.043' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (1, N'Admin', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Role] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (2, N'Kullanici', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Unvan] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (1, 1, N'Komiser', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Unvan] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (2, 1, N'Amir', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Urun] ON 

INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (1, 1, N'Elma', 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (2, 1, N'Kiraz', 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (3, 1, N'Patates', 1, CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (4, 1, N'Makarna', 1, CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (5, 1, N'Çay', 1, CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (6, 1, N'Ekmek', 1, CAST(N'2024-11-28T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Urun] ([Id], [StatusId], [Ad], [MiktarTurId], [LastTransactionDate]) VALUES (7, 1, N'Havuç', 1, CAST(N'2024-11-29T11:36:40.2569170' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Urun] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Surname], [EPosta], [Phone], [StatusId], [LastTransactionDate]) VALUES (1, N'Mustafa', N'Çavdaroğlu', N'mcavdar@gmail.com', N'5412650155', 1, CAST(N'2024-11-12T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicle] ON 

INSERT [dbo].[Vehicle] ([Id], [Plate], [Color], [Year], [FuelType], [BrandId], [ModelId], [DailyPrice], [StatusId], [LastTransactionDate]) VALUES (6, N'string', N'string', 2023, N'string', 1, 1, CAST(1500.00 AS Decimal(18, 2)), 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Vehicle] ([Id], [Plate], [Color], [Year], [FuelType], [BrandId], [ModelId], [DailyPrice], [StatusId], [LastTransactionDate]) VALUES (10, N'string', N'string', 2024, N'string', 1, 1, CAST(2750.00 AS Decimal(18, 2)), 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Vehicle] OFF
GO
ALTER TABLE [dbo].[Model]  WITH CHECK ADD  CONSTRAINT [FK_Model_Brand_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
GO
ALTER TABLE [dbo].[Model] CHECK CONSTRAINT [FK_Model_Brand_BrandId]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Brand_BrandId] FOREIGN KEY([BrandId])
REFERENCES [dbo].[Brand] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Brand_BrandId]
GO
ALTER TABLE [dbo].[Vehicle]  WITH CHECK ADD  CONSTRAINT [FK_Vehicle_Model_ModelId] FOREIGN KEY([ModelId])
REFERENCES [dbo].[Model] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Vehicle] CHECK CONSTRAINT [FK_Vehicle_Model_ModelId]
GO
USE [master]
GO
ALTER DATABASE [AracKiralama] SET  READ_WRITE 
GO
