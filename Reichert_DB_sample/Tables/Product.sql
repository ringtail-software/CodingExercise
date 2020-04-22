CREATE TABLE [dbo].[Product]
(
    [Id] INT NOT NULL IDENTITY, 
    [Name] VARCHAR(100) NOT NULL, 
    [Cost] DECIMAL(10, 2) NOT NULL,
    CONSTRAINT [PK_Product.Id] PRIMARY KEY ([Id])
)
