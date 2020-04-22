CREATE PROCEDURE [dbo].[RecalculateOrder]
    @OrderId int
AS
BEGIN
    DECLARE @discount decimal;
    SELECT @discount = 
        DiscountPercent FROM [dbo].[Customer] WHERE Id =
        (SELECT CustomerId FROM [dbo].[Order] WHERE Id = @OrderId);

    WITH OrderSums (SumOrderId, SumQuantity, SumCost, SumPrice) AS (
        SELECT
	    item.OrderId AS SumOrderId,
        SUM(item.Quantity) AS SumQuantity, 
        SUM(item.Quantity * product.Cost) AS SumCost,
        SUM(item.Quantity * product.Cost * (1 - (@discount / 100))) AS SumPrice
        FROM [dbo].[OrderItem] item
        INNER JOIN [dbo].[Product] product
        ON item.ProductId = product.Id
        WHERE OrderId = @OrderId
        GROUP BY OrderId
    )
    UPDATE [dbo].[Order]
    SET
        TotalQuantity = sums.SumQuantity,
        Cost = sums.SumCost,
        Price = sums.SumPrice
	FROM [dbo].[Order]
	INNER JOIN OrderSums sums ON [dbo].[Order].Id = sums.SumOrderId

END
