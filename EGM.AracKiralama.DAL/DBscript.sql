
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
/****** Object:  Table [dbo].[Brand]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[LogTable]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[MiktarTur]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[Model]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[Personel]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[PersonelSepet]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[PersonelSepetUrun]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[Unvan]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[Urun]    Script Date: 27.11.2024 13:34:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Urun](
	[Id] [int] NOT NULL,
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
/****** Object:  Table [dbo].[User]    Script Date: 27.11.2024 13:34:42 ******/
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
/****** Object:  Table [dbo].[Vehicle]    Script Date: 27.11.2024 13:34:42 ******/
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
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (1, N'Admin', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Role] ([Id], [Name], [StatusId], [LastTransactionDate]) VALUES (2, N'Kullanici', 1, CAST(N'2024-10-15T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
INSERT [dbo].[Unvan] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (1, 1, N'Komiser', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Unvan] ([Id], [StatusId], [Ad], [LastTransactionDate]) VALUES (2, 1, N'Amir', CAST(N'2024-11-27T00:00:00.0000000' AS DateTime2))
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
