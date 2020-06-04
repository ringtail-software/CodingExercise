CREATE TABLE [dbo].[Transactions]
(
	[TransactionId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserGuid] UNIQUEIDENTIFIER NOT NULL, 
    [InvestmentId] INT NOT NULL, 
    [PurchasePrice] MONEY NOT NULL, 
    [PurchaseTimeStamp] DATETIME NOT NULL, 
    [Shares] INT NOT NULL, 
    CONSTRAINT [FK_Transactions_ToInvestments] FOREIGN KEY ([InvestmentId]) REFERENCES [Investments]([InvestmentId])
)
