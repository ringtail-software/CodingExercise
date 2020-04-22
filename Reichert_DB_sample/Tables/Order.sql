CREATE TABLE [dbo].[Order]
(
    [Id] INT NOT NULL IDENTITY, 
    [CustomerId] INT NULL, 
    [UpdatedDate] DATETIME NULL, 
    [TotalQuantity] INT NOT NULL DEFAULT 0, 
    [Cost] DECIMAL(12, 2) NULL, 
    [Price] DECIMAL(12, 2) NULL,
    [IsComplete] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_Order.Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order.CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].Customer([Id])
)
