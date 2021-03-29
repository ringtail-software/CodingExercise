INSTRUCTIONS
------------

The application, by default, should work out the gate with no need to configure anything.  
Simply hit Debug and navigate to /finance/user/{userId} to see every stock the person's got.
Navigate to /finance/user/{userId}/stock/{investmentId} to pinpoint one stock specifically.

There is a setting in appSettings.json called "UseStaticDatabase".  When it is set to true,
application will use a simple in-memory representation of the necessary tables.  When it is
set to false, it will try to target the instance of SQL Server in the 'Default' key of the
ConnectionStrings collection of appSettings.json.  Before you do this, you should run the
script at the end of this README.

-----------
ASSUMPTIONS
-----------

The biggest assumption is I'm not really dealing with security.  No JSON web tokens and
certainly not whitelisting of specific IPs or anything like that.

There's also no caching.  

Finally, there's no sister app that's consuming the data provided by the web request.
Both of my endpoints return full-fledged objects, and there's no viewModel object to
filter the unneeded data.  I ASSUME that's ok.  Unless there's considerable performance 
gains, it's generally better to return a little too much than to try to return every 
permutatation of subset of data... as that gradually becomes a very bloated API.


--- BEGIN SCRIPT FOR [NuixInvestmentz] ---

/****** Object:  Database [NuixInvestmentz]    Script Date: 3/29/2021  ******/


IF EXISTS (SELECT [Name] FROM master.sys.databases WHERE name = N'NuixInvestmentz')
BEGIN
		DROP DATABASE NuixInvestmentz
		PRINT 'NuixInvestmentz already existed.  Dropping...'
	END
ELSE
	PRINT 'NuixInvestmentz does not exist.  Creating...'

--CREATE DATABASE NuixInvestmentz



USE [master]
GO
/****** Object:  Database [NuixInvestmentz]    Script Date: 3/29/2021 4:54:27 PM ******/
CREATE DATABASE [NuixInvestmentz]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NuixInvestmentz', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NuixInvestmentz.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NuixInvestmentz_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NuixInvestmentz_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NuixInvestmentz] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NuixInvestmentz].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NuixInvestmentz] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET ARITHABORT OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NuixInvestmentz] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NuixInvestmentz] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NuixInvestmentz] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NuixInvestmentz] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET RECOVERY FULL 
GO
ALTER DATABASE [NuixInvestmentz] SET  MULTI_USER 
GO
ALTER DATABASE [NuixInvestmentz] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NuixInvestmentz] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NuixInvestmentz] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NuixInvestmentz] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NuixInvestmentz] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'NuixInvestmentz', N'ON'
GO
ALTER DATABASE [NuixInvestmentz] SET QUERY_STORE = OFF
GO
USE [NuixInvestmentz]
GO
/****** Object:  Table [dbo].[Investment]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Investment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](100) NOT NULL,
	[Abbreviation] [nvarchar](10) NOT NULL,
	[CurrentPrice] [decimal](18, 4) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[DeletedDate] [datetime] NULL,
 CONSTRAINT [PK_Investment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[DeletedDate] [datetime] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Password] [varbinary](64) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInvestment]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInvestment](
	[UserId] [int] NOT NULL,
	[InvestmentId] [int] NOT NULL,
	[AveragePurchasePrice] [decimal](18, 4) NOT NULL,
	[CurrentShares] [int] NOT NULL,
	[PriceAtChange] [decimal](18, 4) NOT NULL,
	[ShareDifference] [int] NOT NULL,
	[ChangeTimeStamp] [datetime] NOT NULL,
 CONSTRAINT [PK_UserInvestments] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[InvestmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Investment] ON 
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (1, N'McDonald''s Corporation', N'MCD', CAST(200.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (2, N'Yum! Brands, Inc.', N'YUM', CAST(100.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (3, N'Restaurant Brands International, Inc.', N'QSR', CAST(50.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (4, N'Gold', N'GOLD', CAST(2000.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (5, N'Silver', N'SILV', CAST(25.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (6, N'Rhodium', N'RHOD', CAST(30000.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (7, N'Microsoft Corporation', N'MSFT', CAST(250.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (8, N'Apple Inc', N'AAPL', CAST(125.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[Investment] ([Id], [FullName], [Abbreviation], [CurrentPrice], [CreatedDate], [DeletedDate]) VALUES (9, N'Alphabet Inc Class A', N'GOOGL', CAST(2000.0000 AS Decimal(18, 4)), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Investment] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [DateOfBirth], [DeletedDate], [CreatedDate], [Password]) VALUES (1, N'JJSTONE', N'Jane', N'Jill', N'Stone', CAST(N'1988-10-02T00:00:00.000' AS DateTime), NULL, CAST(N'2021-03-29T12:36:18.903' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [DateOfBirth], [DeletedDate], [CreatedDate], [Password]) VALUES (2, N'RSMASTERS', N'Richard', N'Steven', N'Masters', CAST(N'1971-01-01T00:00:00.000' AS DateTime), NULL, CAST(N'2021-03-28T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [DateOfBirth], [DeletedDate], [CreatedDate], [Password]) VALUES (3, N'IMRICH', N'Ian', N'Michael', N'Rich', CAST(N'1950-12-31T00:00:00.000' AS DateTime), NULL, CAST(N'2021-03-27T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [DateOfBirth], [DeletedDate], [CreatedDate], [Password]) VALUES (4, N'NOACCESS', N'Normal', N'Oswald', N'Access', CAST(N'1990-02-28T00:00:00.000' AS DateTime), CAST(N'2021-03-25T00:00:00.000' AS DateTime), CAST(N'2021-03-20T00:00:00.000' AS DateTime), NULL)
GO
INSERT [dbo].[User] ([Id], [UserName], [FirstName], [MiddleName], [LastName], [DateOfBirth], [DeletedDate], [CreatedDate], [Password]) VALUES (5, N'NOSTOCKS', N'Nicholas', N'Oliver', N'Stocks', CAST(N'1968-07-04T00:00:00.000' AS DateTime), NULL, CAST(N'2021-03-31T00:00:00.000' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
INSERT [dbo].[UserInvestment] ([UserId], [InvestmentId], [AveragePurchasePrice], [CurrentShares], [PriceAtChange], [ShareDifference], [ChangeTimeStamp]) VALUES (1, 4, CAST(1600.0000 AS Decimal(18, 4)), 50, CAST(1600.0000 AS Decimal(18, 4)), 50, CAST(N'2021-03-20T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserInvestment] ([UserId], [InvestmentId], [AveragePurchasePrice], [CurrentShares], [PriceAtChange], [ShareDifference], [ChangeTimeStamp]) VALUES (2, 1, CAST(300.0000 AS Decimal(18, 4)), 100, CAST(300.0000 AS Decimal(18, 4)), 100, CAST(N'2021-03-21T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserInvestment] ([UserId], [InvestmentId], [AveragePurchasePrice], [CurrentShares], [PriceAtChange], [ShareDifference], [ChangeTimeStamp]) VALUES (3, 4, CAST(2000.0000 AS Decimal(18, 4)), 0, CAST(1500.0000 AS Decimal(18, 4)), -50000, CAST(N'2020-06-29T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserInvestment] ([UserId], [InvestmentId], [AveragePurchasePrice], [CurrentShares], [PriceAtChange], [ShareDifference], [ChangeTimeStamp]) VALUES (3, 5, CAST(30.0000 AS Decimal(18, 4)), 0, CAST(15.0000 AS Decimal(18, 4)), -50000, CAST(N'2019-01-31T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserInvestment] ([UserId], [InvestmentId], [AveragePurchasePrice], [CurrentShares], [PriceAtChange], [ShareDifference], [ChangeTimeStamp]) VALUES (3, 7, CAST(225.0000 AS Decimal(18, 4)), 50000, CAST(225.0000 AS Decimal(18, 4)), 50000, CAST(N'2019-04-04T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[UserInvestment] ([UserId], [InvestmentId], [AveragePurchasePrice], [CurrentShares], [PriceAtChange], [ShareDifference], [ChangeTimeStamp]) VALUES (3, 9, CAST(1000.0000 AS Decimal(18, 4)), 60000, CAST(1000.0000 AS Decimal(18, 4)), 60000, CAST(N'2021-02-21T00:00:00.000' AS DateTime))
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_User]    Script Date: 3/29/2021 4:54:27 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Investment] ADD  CONSTRAINT [DF_Investment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[UserInvestment]  WITH CHECK ADD  CONSTRAINT [FK_UserInvestment_Investment] FOREIGN KEY([InvestmentId])
REFERENCES [dbo].[Investment] ([Id])
GO
ALTER TABLE [dbo].[UserInvestment] CHECK CONSTRAINT [FK_UserInvestment_Investment]
GO
ALTER TABLE [dbo].[UserInvestment]  WITH CHECK ADD  CONSTRAINT [FK_UserInvestments_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserInvestment] CHECK CONSTRAINT [FK_UserInvestments_User]
GO
/****** Object:  StoredProcedure [dbo].[Investment_GetAll]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Investment_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		Id,
		FullName,
		Abbreviation,
		CurrentPrice,
		DeletedDate,
		CreatedDate
	FROM
		[Investment]
END
GO
/****** Object:  StoredProcedure [dbo].[Investment_GetById]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Investment_GetById]
(
	@Id int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		Id,
		FullName,
		Abbreviation,
		CurrentPrice,
		DeletedDate,
		CreatedDate
	FROM
		[Investment]
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetAll]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetAll]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		Id,
		UserName,
		FirstName,
		MiddleName,
		LastName,
		DateOfBirth,
		DeletedDate,
		CreatedDate,
		Password
	FROM
		[User]
END
GO
/****** Object:  StoredProcedure [dbo].[User_GetById]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[User_GetById]
(
	@Id int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		Id,
		UserName,
		FirstName,
		MiddleName,
		LastName,
		DateOfBirth,
		DeletedDate,
		CreatedDate,
		Password
	FROM
		[User]
	WHERE
		Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UserInvestment_GetAllInvestmentsByUser]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserInvestment_GetAllInvestmentsByUser]
(
	@UserId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserId
		,InvestmentId
		,AveragePurchasePrice
		,CurrentShares
		,PriceAtChange
		,ShareDifference
		,ChangeTimeStamp
	FROM
		UserInvestment
	WHERE
		UserId = @UserId AND
		(CurrentShares > 0 OR
		DATEADD(YEAR, 1, ChangeTimeStamp) > CURRENT_TIMESTAMP)
END
GO
/****** Object:  StoredProcedure [dbo].[UserInvestment_GetSingleInvestmentByUser]    Script Date: 3/29/2021 4:54:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserInvestment_GetSingleInvestmentByUser]
(
	@UserId int,
	@InvestmentId int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		UserId
		,InvestmentId
		,AveragePurchasePrice
		,CurrentShares
		,PriceAtChange
		,ShareDifference
		,ChangeTimeStamp
	FROM
		UserInvestment
	WHERE
		UserId = @UserId AND
		InvestmentId = @InvestmentId
END
GO
USE [master]
GO
ALTER DATABASE [NuixInvestmentz] SET  READ_WRITE 
GO
