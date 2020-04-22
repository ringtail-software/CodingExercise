CREATE PROCEDURE [dbo].[AddCustomer]
    @firstName varchar(100) = '',
    @lastName varchar(100)
AS
BEGIN
    INSERT INTO [dbo].[Customer]
    (FirstName,LastName)
    VALUES
    (@firstName, @lastName)
END
