USE [master]
GO
/****** Object:  Database [ToyShop]    Script Date: 28.04.2022 11:23:40 ******/
CREATE DATABASE [ToyShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ToyShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToyShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'ToyShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ToyShop_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ToyShop] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ToyShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ToyShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ToyShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ToyShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ToyShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ToyShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [ToyShop] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ToyShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ToyShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ToyShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ToyShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ToyShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ToyShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ToyShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ToyShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ToyShop] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ToyShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ToyShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ToyShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ToyShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ToyShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ToyShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ToyShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ToyShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ToyShop] SET  MULTI_USER 
GO
ALTER DATABASE [ToyShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ToyShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ToyShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ToyShop] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ToyShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ToyShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ToyShop] SET QUERY_STORE = OFF
GO
USE [ToyShop]
GO
/****** Object:  Table [dbo].[Authorization]    Script Date: 28.04.2022 11:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authorization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Right] [nvarchar](50) NULL,
	[Mail] [nvarchar](50) NULL,
	[Fio] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Authorization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Toy]    Script Date: 28.04.2022 11:23:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Toy](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [smallmoney] NOT NULL,
	[Count] [int] NOT NULL,
	[Age] [tinyint] NOT NULL,
	[Factory] [nvarchar](50) NOT NULL,
	[City] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Toy] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authorization] ON 

INSERT [dbo].[Authorization] ([Id], [Login], [Password], [Right], [Mail], [Fio], [Name]) VALUES (1, N'root', N'toor', N'A', N'popa@mail.ru', N'Савельев', N'Дмитрий')
INSERT [dbo].[Authorization] ([Id], [Login], [Password], [Right], [Mail], [Fio], [Name]) VALUES (2, N'дима', N'123', N'P', N'dw@mail.ru', N'Назаров', N'Дмитрий')
SET IDENTITY_INSERT [dbo].[Authorization] OFF
GO
SET IDENTITY_INSERT [dbo].[Toy] ON 

INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (1, N'Кукла Барби', 500.0000, 100, 7, N'Сомов Corporation', N'Рязань')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (3, N'Машинка BMW', 450.0000, 10, 15, N'Сомов Corporation', N'Москва')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (4, N'Машинка Mercedes', 251.0000, 1050, 8, N'Savelev.Base', N'Москва')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (7, N'Mr.Bigzy', 880.0000, 100, 80, N'ИП АННА', N'Рыбное')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (9, N'Конструктор Lego', 1756.0000, 3545, 7, N'LEGO', N'Калининград')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (10, N'Мячик', 100.0000, 1000, 5, N'Abibas Corporation', N'Самара')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (11, N'Коляска для кукол', 1814.0000, 563, 7, N'Melobo', N'Киров')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (12, N'Кукла малыш Bondibon', 948.0000, 7000, 6, N'Bondibon', N'Москва')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (13, N'Носочки для пупсов', 160.0000, 150, 4, N'Happy Vallety', N'Москва')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (14, N'Танцующий кактус', 1247.0000, 234, 7, N'TOYMAGIC', N'Самара')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (15, N'Оптимус Прайм', 1999.0000, 555, 12, N'BAZUMI FABRIC', N'Самара')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (16, N'Жвачка мини-шокер', 192.0000, 1567, 14, N'ДИФ Company', N'Калининград')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (17, N'Набор солдатиков', 132.0000, 764, 13, N'Эврики', N'Калуга')
INSERT [dbo].[Toy] ([Id], [Name], [Price], [Count], [Age], [Factory], [City]) VALUES (18, N'Набор динозавров', 264.0000, 353, 7, N'Сомов Corporation', N'Москва')
SET IDENTITY_INSERT [dbo].[Toy] OFF
GO
USE [master]
GO
ALTER DATABASE [ToyShop] SET  READ_WRITE 
GO
