create database DBDOngHo
USE [DBDOngHo]
GO
/****** Object:  Table [dbo].[Brands]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brands](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[brandName] [nvarchar](50) NULL,
	[brandPiture] [nvarchar](250) NULL,
	[brandDesription] [text] NULL,
	[brandHomePage] [nvarchar](250) NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[id_user] [int] NOT NULL,
	[id_product] [int] NOT NULL,
	[count] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[cateName] [nvarchar](50) NULL,
	[cateDescription] [nvarchar](50) NULL,
	[catePicture] [nvarchar](250) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cusAuthe]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cusAuthe](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nameAuthe] [varchar](50) NULL,
 CONSTRAINT [PK_cusAuthe] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cusAuthe_Roles]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cusAuthe_Roles](
	[idCusAuthe] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
	[Note] [nvarchar](250) NULL,
 CONSTRAINT [PK_cusAuthe_Roles] PRIMARY KEY CLUSTERED 
(
	[idCusAuthe] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[idUser] [int] IDENTITY(1,1) NOT NULL,
	[accuontName] [nvarchar](50) NOT NULL,
	[passWord] [nvarchar](50) NOT NULL,
	[idCusAuthe] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Sex] [bit] NULL,
	[Address] [nvarchar](250) NULL,
	[phoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](250) NOT NULL,
	[dateRegistation] [date] NULL,
	[dateActivated] [date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[idUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Customer__97367C9ECE8E952B] UNIQUE NONCLUSTERED 
(
	[passWord] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ__Customer__A76EB6A17CF04B55] UNIQUE NONCLUSTERED 
(
	[accuontName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Delivery]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Delivery](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id_user] [int] NOT NULL,
	[id_product] [int] NOT NULL,
	[id_stt] [int] NULL,
	[quantity] [int] NULL,
	[total] [decimal](18, 0) NULL,
	[addressTo] [nvarchar](100) NULL,
	[id_deli] [int] NULL,
	[createDate] [date] NULL,
	[requireDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[id_user] ASC,
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[productName] [nvarchar](250) NOT NULL,
	[productDescription] [text] NULL,
	[Price] [decimal](18, 0) NULL,
	[promotionPrice] [decimal](18, 0) NULL,
	[productPicture] [nvarchar](150) NULL,
	[categoryID] [int] NULL,
	[createDate] [date] NULL,
	[viewCount] [int] NULL,
	[productStatus] [bit] NULL,
	[BrandID] [int] NULL,
	[sold] [int] NULL,
	[turnover] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
	[Detail] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 12/31/2020 5:16:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [sold]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT ((0)) FOR [turnover]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[Customers] ([idUser])
GO
ALTER TABLE [dbo].[cusAuthe_Roles]  WITH CHECK ADD  CONSTRAINT [FK_cusAuthe_Roles_cusAuthe] FOREIGN KEY([idCusAuthe])
REFERENCES [dbo].[cusAuthe] ([id])
GO
ALTER TABLE [dbo].[cusAuthe_Roles] CHECK CONSTRAINT [FK_cusAuthe_Roles_cusAuthe]
GO
ALTER TABLE [dbo].[cusAuthe_Roles]  WITH CHECK ADD  CONSTRAINT [FK_cusAuthe_Roles_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[cusAuthe_Roles] CHECK CONSTRAINT [FK_cusAuthe_Roles_Role]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_cusAuthe] FOREIGN KEY([idCusAuthe])
REFERENCES [dbo].[cusAuthe] ([id])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_cusAuthe]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([id_deli])
REFERENCES [dbo].[Delivery] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([id_product])
REFERENCES [dbo].[Products] ([ID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([id_stt])
REFERENCES [dbo].[Status] ([id])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD FOREIGN KEY([id_user])
REFERENCES [dbo].[Customers] ([idUser])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Brands] FOREIGN KEY([BrandID])
REFERENCES [dbo].[Brands] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Brands]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([categoryID])
REFERENCES [dbo].[Categories] ([ID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO
