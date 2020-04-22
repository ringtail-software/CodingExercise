CREATE PROCEDURE [dbo].[GetOrderDetails]
    @OrderId int
AS
BEGIN
    SELECT 
    orderData.Id AS OrderNumber,
    Customer.Id AS CustomerNumber,
    customer.LastName + ', ' + customer.FirstName AS CustomerName,
    orderData.UpdatedDate AS OrderDate,
    orderData.Cost AS OriginalPrice,
    customer.DiscountPercent AS Discount,
    orderData.Price AS FinalPrice
    FROM [dbo].[Order] orderData
    INNER JOIN [dbo].[Customer] customer ON orderData.CustomerId = customer.Id
    WHERE orderData.Id = @OrderId;

    SELECT 
    orderItems.ProductId AS ProductNumber,
    product.Name AS ProductName,
    orderItems.Quantity AS Quantity,
    product.Cost AS Price,
    customer.DiscountPercent AS Discount,
    CONVERT(DECIMAL(12,2),orderItems.Quantity * product.Cost * (1 - (customer.DiscountPercent / 100))) AS DiscountedPrice
    FROM [dbo].[OrderItem] orderItems
    INNER JOIN [dbo].[Product] product ON orderItems.ProductId = product.Id
    INNER JOIN [dbo].[Order] orderData ON orderData.Id = orderItems.OrderId
    INNER JOIN [dbo].[Customer] customer ON orderData.CustomerId = customer.Id
    WHERE orderItems.OrderId = @OrderId
    ORDER BY orderItems.Id;

END