CREATE PROCEDURE [dbo].[AddOrderItem]
    @ProductId int,
    @Quantity int,
    @CustomerId int
AS
BEGIN
    DECLARE @Order int;

    SELECT @Order = ISNULL(MIN(Id),0)
    FROM [dbo].[Order] 
    WHERE CustomerId = @CustomerId AND IsComplete = 0;

    IF (@Order = 0)
    BEGIN
        INSERT INTO [dbo].[Order]
        (CustomerId,UpdatedDate,TotalQuantity)
        VALUES
        (@CustomerId, GETDATE(),@Quantity);

        SELECT @Order = SCOPE_IDENTITY();
    END

    INSERT INTO [dbo].[OrderItem]
    (ProductId, Quantity, OrderId)
    VALUES
    (@ProductId,@Quantity, @Order);
    
    EXEC [dbo].[RecalculateOrder] @OrderId = @Order;

    RETURN @Order;
END
