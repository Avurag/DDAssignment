USE [DignitasDigital]
GO
ALTER TABLE [dbo].[NameList] DROP CONSTRAINT [FK_Grid_Users]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/13/2020 9:00:27 AM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[NameList]    Script Date: 9/13/2020 9:00:27 AM ******/
DROP TABLE [dbo].[NameList]
GO
/****** Object:  Table [dbo].[NameList]    Script Date: 9/13/2020 9:00:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NameList](
	[SeqID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NULL,
	[UpdatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_Grid] PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/13/2020 9:00:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Username] [nvarchar](200) NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](200) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](200) NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Username], [Password], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedOn]) VALUES (1, N'anurag', N'pathania', N'admin', N'12345', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[NameList]  WITH CHECK ADD  CONSTRAINT [FK_Grid_Users] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[NameList] CHECK CONSTRAINT [FK_Grid_Users]
GO
