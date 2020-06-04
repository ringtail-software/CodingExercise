CREATE TABLE [dbo].[Investments]
(
	[InvestmentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Type] INT NOT NULL
)
