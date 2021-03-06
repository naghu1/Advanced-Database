USE [master]
GO
/****** Object:  Database [laptopdb]    Script Date: 25/04/2019 08:04:47 ******/
CREATE DATABASE [laptopdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'laptopdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\laptopdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'laptopdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\laptopdb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [laptopdb] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [laptopdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [laptopdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [laptopdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [laptopdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [laptopdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [laptopdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [laptopdb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [laptopdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [laptopdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [laptopdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [laptopdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [laptopdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [laptopdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [laptopdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [laptopdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [laptopdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [laptopdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [laptopdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [laptopdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [laptopdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [laptopdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [laptopdb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [laptopdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [laptopdb] SET RECOVERY FULL 
GO
ALTER DATABASE [laptopdb] SET  MULTI_USER 
GO
ALTER DATABASE [laptopdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [laptopdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [laptopdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [laptopdb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [laptopdb] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'laptopdb', N'ON'
GO
ALTER DATABASE [laptopdb] SET QUERY_STORE = OFF
GO
USE [laptopdb]
GO
/****** Object:  Table [dbo].[tbl_Services]    Script Date: 25/04/2019 08:04:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Services](
	[ServiceID] [int] NOT NULL,
	[ServiceName] [varchar](50) NOT NULL,
	[ServiceRate] [real] NOT NULL,
	[BranchID] [int] NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ServiceLine]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ServiceLine](
	[ServiceNumber] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalServicePrice] [real] NOT NULL,
	[ServiceDate] [date] NOT NULL,
	[ServiceID] [int] NULL,
	[OrderID] [int] NULL,
	[SerialNo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Service_Price]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Service_Price] 
AS
SELECT 
ServiceName, TotalServicePrice
from tbl_Services s left join tbl_ServiceLine l
on
s.ServiceID =  l.ServiceID  
GO
/****** Object:  Table [dbo].[tbl_Order]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Order](
	[OrderID] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[TotalAmount] [int] NOT NULL,
	[ClientID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Laptop]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Laptop](
	[SerialNo] [int] NOT NULL,
	[Model] [varchar](50) NOT NULL,
	[Company] [varchar](50) NOT NULL,
	[ClientID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SerialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[tablesview]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[tablesview] 
 AS
SELECT 
Model, ServiceName, OrderDate
from tbl_Laptop s left join tbl_Services t
on  s.SerialNo =  t.ServiceID 
left join tbl_Order c
on t.ServiceID = c.OrderID
GO
/****** Object:  Table [dbo].[Order_Details]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Details](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Details_Data] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Branch]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Branch](
	[BranchID] [int] NOT NULL,
	[BranchName] [varchar](50) NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[EIRCode] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[CategoryID] [int] NOT NULL,
	[CategoryType] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Client]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Client](
	[ClientID] [int] NOT NULL,
	[ClientName] [varchar](100) NOT NULL,
	[ClientEmail_Address] [varchar](100) NULL,
	[ClientContact_no] [int] NOT NULL,
	[Street] [varchar](100) NOT NULL,
	[City] [varchar](30) NOT NULL,
	[EIRCode] [int] NOT NULL,
	[Feedback] [xml] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[ClientName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Laptop]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[tbl_Client] ([ClientID])
GO
ALTER TABLE [dbo].[tbl_Order]  WITH CHECK ADD FOREIGN KEY([ClientID])
REFERENCES [dbo].[tbl_Client] ([ClientID])
GO
ALTER TABLE [dbo].[tbl_ServiceLine]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[tbl_Order] ([OrderID])
GO
ALTER TABLE [dbo].[tbl_ServiceLine]  WITH CHECK ADD FOREIGN KEY([SerialNo])
REFERENCES [dbo].[tbl_Laptop] ([SerialNo])
GO
ALTER TABLE [dbo].[tbl_ServiceLine]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[tbl_Services] ([ServiceID])
GO
ALTER TABLE [dbo].[tbl_Services]  WITH CHECK ADD FOREIGN KEY([BranchID])
REFERENCES [dbo].[tbl_Branch] ([BranchID])
GO
ALTER TABLE [dbo].[tbl_Services]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[tbl_Category] ([CategoryID])
GO
/****** Object:  StoredProcedure [dbo].[Countquantity]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Countquantity] @quantity int
AS
BEGIN
SELECT Quantity,COUNT(*) as [counting quantity for service date]
from tbl_ServiceLine
WHERE Quantity=@quantity
GROUP BY Quantity
END
GO
/****** Object:  StoredProcedure [dbo].[GetLaptopServiceDetails]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetLaptopServiceDetails]
AS
BEGIN
SELECT t1.SerialNo,t1.Model,t2.ServiceDate,t2.Quantity,t2.ServiceNumber FROM tbl_Laptop t1 inner join tbl_ServiceLine t2 on t1.SerialNo=t2.SerialNo
END
GO
/****** Object:  StoredProcedure [dbo].[Groupby]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Groupby]
AS
BEGIN
SELECT  OrderDate O, 
        SUM(TotalServicePrice) 
		AS TotalSpent
FROM  tbl_Order O , tbl_ServiceLine S
WHERE    O.OrderID = S.OrderID
GROUP BY O.OrderDate
END
GO
/****** Object:  StoredProcedure [dbo].[GroupbyHaving]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GroupbyHaving]
AS
BEGIN
Select Quantity, SUM(TotalServicePrice)
From tbl_ServiceLine
GROUP by Quantity
having SUM(TotalServicePrice)>1000
END
GO
/****** Object:  StoredProcedure [dbo].[LaptopService]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Procedure [dbo].[LaptopService]
@ClientEmail_Address varchar (40)
AS
UPDATE tbl_Client
SET ClientEmail_Address=@ClientEmail_Address
WHERE ClientEmail_Address='ena.maha@gmail.com'
GO
/****** Object:  StoredProcedure [dbo].[RetrieveAllDetails]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RetrieveAllDetails]
AS
SELECT C.ClientName,C.ClientContact_no,L.Model,SL.Quantity,SL.ServiceDate,S.ServiceName,S.ServiceRate,B.BranchName,B.EIRCode,CT.CategoryType

FROM  tbl_Client C with (nolock)

left JOIN tbl_Laptop L  (NOLOCK) ON C.ClientID = L.ClientID

left Join tbl_ServiceLine SL on L.SerialNo = SL.SerialNo

left Join tbl_Services S on SL.ServiceID = S.ServiceID

left Join tbl_Branch B on S.BranchID = B.BranchID

left Join tbl_Category CT on CT.CategoryID = S.CategoryID

GO
/****** Object:  StoredProcedure [dbo].[SelectPremiumUsers]    Script Date: 25/04/2019 08:04:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectPremiumUsers] @CategoryType varchar(20)
AS
SELECT * FROM tbl_Category WHERE CategoryType = @CategoryType; 
GO
USE [master]
GO
ALTER DATABASE [laptopdb] SET  READ_WRITE 
GO
