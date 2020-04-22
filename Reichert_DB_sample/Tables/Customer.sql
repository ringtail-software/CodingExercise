CREATE TABLE [dbo].[Customer]
(
    [Id] INT NOT NULL IDENTITY, 
    [FirstName] VARCHAR(100) NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [DiscountPercent] DECIMAL(3, 2) NOT NULL DEFAULT 0,
    CONSTRAINT [PK_Customer.Id] PRIMARY KEY ([Id])
)
