/*
Post-Deployment Script Template                            
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.        
 Use SQLCMD syntax to include a file in the post-deployment script.            
 Example:      :r .\myfile.sql                                
 Use SQLCMD syntax to reference a variable in the post-deployment script.        
 Example:      :setvar TableName MyTable                            
               SELECT * FROM [$(TableName)]                    
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[Customer] ON;
GO
MERGE INTO [dbo].[Customer] AS Target
USING (VALUES
(1,'Hank','Frankly'),
(2,'Bob','Loblaw'),
(3,'George','Porj')
) AS Source ([Id],[FirstName],[LastName])
ON Target.[Id] = Source.[Id]
WHEN MATCHED THEN
UPDATE SET
[FirstName] = Source.[FirstName],
[LastName] = Source.[LastName]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[FirstName],[LastName])
VALUES ([Id],[FirstName],[LastName]);
SET IDENTITY_INSERT [dbo].[Customer] OFF;
GO

SET IDENTITY_INSERT [dbo].[Product] ON;
GO
MERGE INTO [dbo].[Product] AS Target
USING (VALUES
(1,'Widget',1.37),
(2,'Gadget',7.99),
(3,'Shamwow',0.17),
(4,'Telescope',300.00),
(5,'Rock',20.00)
) AS Source ([Id],[Name],[Cost])
ON Target.[Id] = Source.[Id]
WHEN MATCHED THEN
UPDATE SET
[Name] = Source.[Name],
[Cost] = Source.[Cost]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Name],[Cost])
VALUES ([Id],[Name],[Cost]);
SET IDENTITY_INSERT [dbo].[Product] OFF;
GO


SET IDENTITY_INSERT [dbo].[Order] ON;
GO
MERGE INTO [dbo].[Order] AS Target
USING (VALUES
(1,1,'3/3/2020',1),
(2,2,'3/4/2020',1),
(3,3,'3/5/2020',1),
(4,1,'3/27/2020',1),
(5,3,'3/28/2020',1),
(6,3,'3/28/2020',1)
) AS  Source ([Id],[CustomerId],[UpdatedDate],[IsComplete])
ON Target.[Id] = Source.[Id]
WHEN MATCHED THEN
UPDATE SET
[CustomerId] = Source.[CustomerId],
[UpdatedDate] = Source.[UpdatedDate],
[IsComplete] = Source.[IsComplete]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[CustomerId],[UpdatedDate],[IsComplete])
VALUES ([Id],[CustomerId],[UpdatedDate],[IsComplete]);
GO
SET IDENTITY_INSERT [dbo].[Order] OFF;
GO


DELETE FROM [dbo].[OrderItem];
INSERT INTO [dbo].[OrderItem]
([ProductId],[Quantity],[OrderId])
VALUES
(1,800,1),
(3,2000,1),
(4,5,1),
(5,5000,4),
(4,1000,2),
(2,100,3),
(3,100,5),
(5,100,6)

Exec [dbo].[RecalculateOrder] @OrderId = 1;
Exec [dbo].[RecalculateOrder] @OrderId = 2;
Exec [dbo].[RecalculateOrder] @OrderId = 3;
Exec [dbo].[RecalculateOrder] @OrderId = 4;
Exec [dbo].[RecalculateOrder] @OrderId = 5;
Exec [dbo].[RecalculateOrder] @OrderId = 6;

Exec [dbo].[UpdateCustomerDiscount] @customerId = 1;
Exec [dbo].[UpdateCustomerDiscount] @customerId = 2;
Exec [dbo].[UpdateCustomerDiscount] @customerId = 3;


