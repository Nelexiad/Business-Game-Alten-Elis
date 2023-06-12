USE [ONLINE_STORE]
GO
/****** Object:  Table [dbo].[Available_Products]    Script Date: 12/06/2023 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Available_Products](
	[ID_Available_Product] [int] IDENTITY(1,1) NOT NULL,
	[ID_Shop] [int] NOT NULL,
	[ID_Product] [int] NOT NULL,
	[Available_Amount] [int] NOT NULL,
 CONSTRAINT [PK_Available_Products] PRIMARY KEY CLUSTERED 
(
	[ID_Available_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart_Product]    Script Date: 12/06/2023 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_Product](
	[ID_Cart_Product] [int] IDENTITY(1,1) NOT NULL,
	[ID_Cart] [int] NOT NULL,
	[ID_Product] [int] NOT NULL,
	[Amout] [int] NOT NULL,
 CONSTRAINT [PK_Cart_Product] PRIMARY KEY CLUSTERED 
(
	[ID_Cart_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 12/06/2023 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[ID_Cart] [int] IDENTITY(1,1) NOT NULL,
	[ID_User] [int] NOT NULL,
 CONSTRAINT [PK_Carts] PRIMARY KEY CLUSTERED 
(
	[ID_Cart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/06/2023 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID_Product] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID_Product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shops]    Script Date: 12/06/2023 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shops](
	[ID_Shop] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Shops] PRIMARY KEY CLUSTERED 
(
	[ID_Shop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/06/2023 15:40:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Surname] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Available_Products]  WITH CHECK ADD  CONSTRAINT [FK_Available_Products_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Products] ([ID_Product])
GO
ALTER TABLE [dbo].[Available_Products] CHECK CONSTRAINT [FK_Available_Products_Product]
GO
ALTER TABLE [dbo].[Available_Products]  WITH CHECK ADD  CONSTRAINT [FK_Available_Products_Shop] FOREIGN KEY([ID_Shop])
REFERENCES [dbo].[Shops] ([ID_Shop])
GO
ALTER TABLE [dbo].[Available_Products] CHECK CONSTRAINT [FK_Available_Products_Shop]
GO
ALTER TABLE [dbo].[Cart_Product]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Cart] FOREIGN KEY([ID_Cart])
REFERENCES [dbo].[Carts] ([ID_Cart])
GO
ALTER TABLE [dbo].[Cart_Product] CHECK CONSTRAINT [FK_Cart_Cart]
GO
ALTER TABLE [dbo].[Cart_Product]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product_Product_Product] FOREIGN KEY([ID_Product])
REFERENCES [dbo].[Products] ([ID_Product])
GO
ALTER TABLE [dbo].[Cart_Product] CHECK CONSTRAINT [FK_Cart_Product_Product_Product]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Cart_User] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Cart_User]
GO
