CREATE PROCEDURE [dbo].[AddProduct]
    @Name varchar(100),
    @Cost decimal(10,2)
AS
BEGIN
    INSERT INTO [dbo].[Product]
    (Name, Cost)
    VALUES
    (@Name, @Cost)
END
