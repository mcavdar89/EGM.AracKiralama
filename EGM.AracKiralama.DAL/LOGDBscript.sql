
CREATE TABLE [dbo].[ErrorLogTable](
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
 CONSTRAINT [PK_ErrorLogTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogTable]    Script Date: 27.11.2024 13:47:52 ******/
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
USE [master]
GO
ALTER DATABASE [LogDB] SET  READ_WRITE 
GO
