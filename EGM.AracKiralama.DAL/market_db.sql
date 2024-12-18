USE [AracKiralama]
GO
/****** Object:  Table [dbo].[MaketUrun]    Script Date: 28.11.2024 16:45:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaketUrun](
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
/****** Object:  Table [dbo].[Market]    Script Date: 28.11.2024 16:45:20 ******/
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
SET IDENTITY_INSERT [dbo].[Market] ON 

INSERT [dbo].[Market] ([Id], [StatusId], [Ad], [Adres], [Puan], [LastTransactionDate]) VALUES (1, 1, N'Güler Market', NULL, NULL, CAST(N'2024-11-28T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Market] OFF
GO
