SET IDENTITY_INSERT dbo.Users ON;

MERGE dbo.Users AS TARGET
USING (VALUES
	(1, 'Test', 'User1'),
	(2, 'Test', 'User2'),
	(3, 'Test', 'User3')
) AS SOURCE (UserId, FirstName, LastName)
ON (TARGET.UserId = SOURCE.UserId)
WHEN NOT MATCHED BY TARGET THEN
	INSERT (UserId, FirstName, LastName)
	VALUES (SOURCE.UserId, SOURCE.FirstName, SOURCE.LastName);

SET IDENTITY_INSERT dbo.Users OFF;

SET IDENTITY_INSERT dbo.Investments ON;

MERGE dbo.Investments AS TARGET
USING (VALUES
	(1, 'TSLA', 442.30),
	(2, 'AMZN', 3442.93),
	(3, 'MSFT', 221.40),
	(4, 'SPY', 352.43)
) AS SOURCE (InvestmentId, [Name], CurrentPrice)
ON (TARGET.InvestmentId = SOURCE.InvestmentId)
WHEN NOT MATCHED BY TARGET THEN
	INSERT (InvestmentId, [Name], CurrentPrice)
	VALUES (SOURCE.InvestmentId, SOURCE.[Name], SOURCE.CurrentPrice);

SET IDENTITY_INSERT dbo.Investments OFF;

MERGE dbo.UserInvestments AS TARGET
USING (VALUES
	(1, 1, 1000, 49.423, '10/14/19'),
	(1, 3, 3000, 132.52, '3/23/20'),
	(2, 2, 2000, 1626.03, '3/16/20'),
	(2, 4, 4000, 218.26, '3/23/20')
) AS SOURCE (UserId, InvestmentId, Shares, CostBasis, DatePurchased)
ON (TARGET.UserId = SOURCE.UserId AND TARGET.InvestmentId = SOURCE.InvestmentId)
WHEN NOT MATCHED BY TARGET THEN
	INSERT (UserId, InvestmentId, Shares, CostBasis, DatePurchased)
	VALUES (SOURCE.UserId, SOURCE.InvestmentId, SOURCE.Shares, SOURCE.CostBasis, SOURCE.DatePurchased);

