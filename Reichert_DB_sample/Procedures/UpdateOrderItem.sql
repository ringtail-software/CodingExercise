CREATE PROCEDURE [dbo].[UpdateOrderItem]
    @OrderItemId int,
    @Quantity int
AS
BEGIN
    DECLARE @Order int;

    SELECT @Order = OrderId
    FROM [dbo].[OrderItem] 
    WHERE Id = @OrderItemId;

    UPDATE [dbo].[OrderItem]
    SET Quantity = @Quantity
    WHERE Id = @OrderItemId;

    UPDATE [dbo].[Order]
    SET UpdatedDate = GETDATE()
    WHERE Id = @Order;
    
    EXEC [dbo].[RecalculateOrder] @OrderId = @Order
END
