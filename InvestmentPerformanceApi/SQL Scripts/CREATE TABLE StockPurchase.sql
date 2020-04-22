USE [Investment]
GO

/****** Object:  Table [dbo].[StockPurchase]    Script Date: 4/22/2020 3:07:33 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockPurchase](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[StockId] [int] NOT NULL,
	[PurchaseCostPerShare] [smallmoney] NOT NULL,
	[Shares] [int] NOT NULL,
	[PurchaseDate] [date] NOT NULL,
 CONSTRAINT [PK_StockPurchase] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StockPurchase]  WITH CHECK ADD  CONSTRAINT [FK_StockPurchase_Stock] FOREIGN KEY([StockId])
REFERENCES [dbo].[Stock] ([Id])
GO

ALTER TABLE [dbo].[StockPurchase] CHECK CONSTRAINT [FK_StockPurchase_Stock]
GO

ALTER TABLE [dbo].[StockPurchase]  WITH CHECK ADD  CONSTRAINT [FK_StockPurchase_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

ALTER TABLE [dbo].[StockPurchase] CHECK CONSTRAINT [FK_StockPurchase_User]
GO


