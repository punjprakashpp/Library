USE [Library]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 13-07-2024 07:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Entrydate] [nvarchar](50) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [dbo].[Admin]
			([Name],
			[UserName],
			[Password],
			[Entrydate])
     VALUES
           ('Librarian',
			'admin',
			'P@$$w0rd',
			'01-01-2024')
GO
/****** Object:  Table [dbo].[Book]    Script Date: 13-07-2024 07:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BID] [int] IDENTITY(1,1) NOT NULL,
	[BookNo] [nvarchar](50) NULL,
	[BookName] [nvarchar](100) NULL,
	[Author] [nvarchar](50) NULL,
	[Detail] [nvarchar](250) NULL,
	[Publication] [nvarchar](100) NULL,
	[PubDate] [date] NULL,
	[Price] [float] NULL,
	[ImagePath] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[BID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rent]    Script Date: 13-07-2024 07:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rent](
	[RID] [int] IDENTITY(1,1) NOT NULL,
	[BID] [int] NULL,
	[SID] [int] NULL,
	[IssueDate] [datetime] NULL,
	[ReturnDate] [datetime] NULL,
	[Status] [int] NULL,
	[Penalty] [int] NULL,
	[Amount] [float] NULL,
	[Detail] [nvarchar](500) NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_RentMst] PRIMARY KEY CLUSTERED 
(
	[RID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 13-07-2024 07:40:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[SID] [int] IDENTITY(1,1) NOT NULL,
	[Session] [nvarchar](50) NULL,
	[Roll] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Pincode] [nvarchar](50) NULL,
	[DOB] [datetime] NULL,
	[Gender] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[ImagePath] [nvarchar](500) NULL,
	[EntryDate] [datetime] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[SID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
