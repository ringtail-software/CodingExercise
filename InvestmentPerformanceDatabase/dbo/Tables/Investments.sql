CREATE TABLE [dbo].[Investments] (
    [InvestmentId]   INT             IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (100)  NOT NULL,
    [CurrentPrice]   DECIMAL (19, 4) NOT NULL,
    CONSTRAINT [PK_Investments] PRIMARY KEY CLUSTERED ([InvestmentId] ASC)
);

