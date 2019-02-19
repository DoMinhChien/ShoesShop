USE [master]
GO
/****** Object:  Database [StoreManagement]    Script Date: 2/19/2019 9:30:05 PM ******/
CREATE DATABASE [StoreManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StoreManagement', FILENAME = N'D:\Tools\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StoreManagement.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'StoreManagement_log', FILENAME = N'D:\Tools\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\StoreManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [StoreManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StoreManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StoreManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StoreManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StoreManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StoreManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StoreManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StoreManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StoreManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StoreManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StoreManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StoreManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StoreManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StoreManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StoreManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StoreManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StoreManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StoreManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StoreManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StoreManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StoreManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [StoreManagement] SET  MULTI_USER 
GO
ALTER DATABASE [StoreManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StoreManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StoreManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StoreManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [StoreManagement] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'StoreManagement', N'ON'
GO
USE [StoreManagement]
GO
/****** Object:  Table [dbo].[TblCategories]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCategories](
	[CategoryId] [int] NOT NULL,
	[CategoryName] [nvarchar](50) NOT NULL,
	[CategoryDescription] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCustomerLevels]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCustomerLevels](
	[LevelId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LevelPoint] [int] NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_CustomerLevels] PRIMARY KEY CLUSTERED 
(
	[LevelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblCustomers]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblCustomers](
	[CustomerId] [uniqueidentifier] NOT NULL,
	[CustomerName] [nvarchar](100) NOT NULL,
	[Phone] [nchar](15) NULL,
	[Address] [nvarchar](50) NULL,
	[LevelId] [int] NOT NULL,
	[Point] [float] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[DepartmentId] [int] NOT NULL,
	[DepartmentName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblEmployees]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmployees](
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[HireDate] [datetime] NOT NULL,
	[Phone] [nchar](10) NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[ImageUrl] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[DepartmentId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TblImageStore]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TblImageStore](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ObjectId] [uniqueidentifier] NOT NULL,
	[ImageName] [nvarchar](1000) NULL,
	[ImageByte] [image] NULL,
	[ImagePath] [nvarchar](1000) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_TblImageStore] PRIMARY KEY CLUSTERED 
(
	[ImageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrderDetails]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderDetails](
	[OrderId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[Discount] [real] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrders]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrders](
	[OrderId] [uniqueidentifier] NOT NULL,
	[CustomerId] [uniqueidentifier] NOT NULL,
	[EmployeeId] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[StatusId] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblOrderStatus]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblOrderStatus](
	[StatusId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProducts]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProducts](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[CategoryId] [int] NOT NULL,
	[SupplierId] [uniqueidentifier] NOT NULL,
	[Quantity] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[CreatedBy] [uniqueidentifier] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [uniqueidentifier] NULL,
	[ViewCounts] [int] NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[UnitPrice] [float] NULL,
	[UnitsInStock] [int] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblProductsStatus]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProductsStatus](
	[StatusId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DisplayOrder] [int] NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
 CONSTRAINT [PK_ProductsStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblSuppliers]    Script Date: 2/19/2019 9:30:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSuppliers](
	[SupplierId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Country] [nchar](50) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT ((0)),
	[CreatedBy] [uniqueidentifier] NOT NULL DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726'),
	[ModifiedBy] [uniqueidentifier] NULL,
	[CreatedOn] [datetime] NOT NULL DEFAULT (getdate()),
	[ModifiedOn] [datetime] NULL,
	[ImageId] [int] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblOrderDetails] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblOrderDetails] ADD  DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[tblOrderDetails] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[tblOrders] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblOrders] ADD  DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[tblOrderStatus] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[tblOrderStatus] ADD  DEFAULT ('6E2B9DE4-B456-4263-A0F7-CE0432556726') FOR [CreatedBy]
GO
ALTER TABLE [dbo].[tblOrderStatus] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[TblCustomers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_CustomerLevels] FOREIGN KEY([LevelId])
REFERENCES [dbo].[TblCustomerLevels] ([LevelId])
GO
ALTER TABLE [dbo].[TblCustomers] CHECK CONSTRAINT [FK_Customers_CustomerLevels]
GO
ALTER TABLE [dbo].[tblEmployees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[tblDepartment] ([DepartmentId])
GO
ALTER TABLE [dbo].[tblEmployees] CHECK CONSTRAINT [FK_Employees_Department]
GO
ALTER TABLE [dbo].[TblImageStore]  WITH CHECK ADD  CONSTRAINT [FK_TblImageStore_Product] FOREIGN KEY([ObjectId])
REFERENCES [dbo].[tblProducts] ([Id])
GO
ALTER TABLE [dbo].[TblImageStore] CHECK CONSTRAINT [FK_TblImageStore_Product]
GO
ALTER TABLE [dbo].[tblOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[tblProducts] ([Id])
GO
ALTER TABLE [dbo].[tblOrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Products]
GO
ALTER TABLE [dbo].[tblOrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_Orders_OrderDetails] FOREIGN KEY([OrderId])
REFERENCES [dbo].[tblOrders] ([OrderId])
GO
ALTER TABLE [dbo].[tblOrderDetails] CHECK CONSTRAINT [FK_Orders_OrderDetails]
GO
ALTER TABLE [dbo].[tblOrders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomers] ([CustomerId])
GO
ALTER TABLE [dbo].[tblOrders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[tblOrders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([OrderId])
REFERENCES [dbo].[tblEmployees] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblOrders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[tblOrders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Statues] FOREIGN KEY([StatusId])
REFERENCES [dbo].[tblOrderStatus] ([StatusId])
GO
ALTER TABLE [dbo].[tblOrders] CHECK CONSTRAINT [FK_Orders_Statues]
GO
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[TblCategories] ([CategoryId])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK_Products_Categories]
GO
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK_Products_Employees] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[tblEmployees] ([EmployeeId])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK_Products_Employees]
GO
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK_Products_Statues] FOREIGN KEY([StatusId])
REFERENCES [dbo].[tblProductsStatus] ([StatusId])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK_Products_Statues]
GO
ALTER TABLE [dbo].[tblProducts]  WITH CHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierId])
REFERENCES [dbo].[tblSuppliers] ([SupplierId])
GO
ALTER TABLE [dbo].[tblProducts] CHECK CONSTRAINT [FK_Products_Suppliers]
GO
ALTER TABLE [dbo].[tblSuppliers]  WITH CHECK ADD  CONSTRAINT [FK_tblSuppliers_ImageStore] FOREIGN KEY([ImageId])
REFERENCES [dbo].[TblImageStore] ([ImageId])
GO
ALTER TABLE [dbo].[tblSuppliers] CHECK CONSTRAINT [FK_tblSuppliers_ImageStore]
GO
USE [master]
GO
ALTER DATABASE [StoreManagement] SET  READ_WRITE 
GO
