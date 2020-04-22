CREATE TABLE [dbo].[OrderItem]
(
    [Id] INT NOT NULL IDENTITY, 
    [ProductId] INT NOT NULL, 
    [Quantity] INT NOT NULL, 
    [OrderId] INT NULL,
    CONSTRAINT [PK_OrderItem.Id] PRIMARY KEY ([Id]),
    CONSTRAINT [PK_OrderItem.ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product]([Id]),
    CONSTRAINT [FK_OrderItem.OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order]([Id])
)
