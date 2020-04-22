CREATE PROCEDURE [dbo].[UpdateCustomerDiscount]
    @customerId int
AS
BEGIN
    DECLARE @firstOfQuarter DATE, @firstOfLastQuarter DATE;
    DECLARE @lastQuarterTotal DECIMAL(15,2);
    SET @firstOfQuarter = 
        DATEFROMPARTS(
	        DATEPART(YEAR,GETDATE()),
	        1 + DATEPART(MONTH,getdate()) - (DATEPART(MONTH,getdate()) % 3),
	        1);
    SET @firstOfLastQuarter = DATEADD(MONTH,-3,@firstOfQuarter);

    SELECT @lastQuarterTotal = SUM(Cost) 
    FROM [dbo].[Order]
    WHERE CustomerId = @customerId
        AND UpdatedDate >= @firstOfLastQuarter
        AND UpdatedDate < @firstOfQuarter
        AND IsComplete = 1
    GROUP BY Cost;

    UPDATE [dbo].[Customer]
    SET DiscountPercent = 
        CASE WHEN @lastQuarterTotal > 1000000 THEN 7
        WHEN @lastQuarterTotal > 25000 THEN 6
        WHEN @lastQuarterTotal > 10000 THEN 5
        WHEN @lastQuarterTotal > 5000 THEN 4
        WHEN @lastQuarterTotal > 1000 THEN 2
        ELSE 0
        END
    WHERE Id = @customerId;
END