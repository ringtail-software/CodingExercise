CREATE PROCEDURE [dbo].[DeleteOrderItem]
    @OrderItemId int
AS
BEGIN
    DECLARE @Order int, @OrderCount int;;

    SELECT @Order = OrderId
    FROM [dbo].[OrderItem] 
    WHERE Id = @OrderItemId;

    SELECT @OrderCount = COUNT(*)
    FROM [dbo].[OrderItem]
    WHERE OrderId = @Order;

    DELETE FROM [dbo].[OrderItem]
    WHERE Id = @OrderItemId;

    IF (@OrderCount = 1) 
        DELETE FROM [dbo].[Order]
        WHERE Id = @Order
    ELSE
        UPDATE [dbo].[Order]
        SET UpdatedDate = GETDATE()
        WHERE Id = @Order;

        EXEC [dbo].[RecalculateOrder] @OrderId = @Order;

END
