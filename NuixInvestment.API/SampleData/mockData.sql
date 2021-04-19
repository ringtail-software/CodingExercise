-- Mock User Investments; output investments.json
DECLARE @UserId INT
DECLARE @tblInvestments TABLE(UserId INT, InvestmentId INT, Ticker VARCHAR(25))
DECLARE @tblInvestmentDetails TABLE(UserId INT, InvestmentId INT, Shares BIGINT, PurchasedPrice MONEY, CurrentPrice MONEY, PurchasedDate DATETIME)

SET @UserId = (ROUND(RAND(1) * 1000, 0))

INSERT INTO @tblInvestments
VALUES(@UserId, ROUND(RAND() * 1000, 0), 'AAPL'),
(@UserId, ROUND(RAND() * 1000, 0), 'BTC'),
(@UserId, ROUND(RAND() * 1000, 0), 'ETH'),
(@UserId, ROUND(RAND() * 1000, 0), 'MSFT'),
(@UserId, ROUND(RAND() * 1000, 0), 'TSLA'),
(@UserId, ROUND(RAND() * 1000, 0), 'FB'),
(@UserId, ROUND(RAND() * 1000, 0), 'GOOG'),
(@UserId, ROUND(RAND() * 1000, 0), 'NFLX'),
(@UserId, ROUND(RAND() * 1000, 0), 'MRNA'),
(@UserId, ROUND(RAND() * 1000, 0), 'PFE')

SELECT *
FROM @tblInvestments
FOR JSON PATH

-- Mock User Investment Details; output investmentdetails.json
INSERT INTO @tblInvestmentDetails
VALUES(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'AAPL'), ROUND(RAND() * 1000, 0), '134.56', '123.45', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'BTC'), ROUND(RAND() * 1000, 0), '2134.56', '63123.78', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'ETH'), ROUND(RAND() * 1000, 0), '834.56', '2423.40', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'MSFT'), ROUND(RAND() * 1000, 0), '194.56', '245.45', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'TSLA'), ROUND(RAND() * 1000, 0), '134.56', '893.49', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'FB'), ROUND(RAND() * 1000, 0), '34.56', '323.45', GETDATE()),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'GOOG'), ROUND(RAND() * 1000, 0), '434.56', '1123.45', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'NFLX'), ROUND(RAND() * 1000, 0), '14.56', '323.45', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'MRNA'), ROUND(RAND() * 1000, 0), '34.56', '124.55', DATEADD(DAY, ABS(CHECKSUM(NEWID()) % 3650), '2000-01-01')),
(@UserId, (SELECT InvestmentId FROM @tblInvestments WHERE Ticker = 'PFE'), ROUND(RAND() * 1000, 0), '13.56', '34.45', GETDATE())
 
-- SELECT *
-- FROM @tblInvestmentDetails
-- FOR JSON PATH

SELECT d.UserId, d.InvestmentId, (SELECT Ticker FROM @tblInvestments WHERE InvestmentId = d.InvestmentId) AS Ticker, PurchasedPrice, Shares * CurrentPrice AS Val, CurrentPrice,
       CASE WHEN DATEDIFF(YEAR, PurchasedDate, GETDATE()) <= 1 THEN 'Short' ELSE 'Long' END AS [Term],
       (CurrentPrice - PurchasedPrice) * Shares AS NetGain
FROM @tblInvestmentDetails d
FOR JSON PATH