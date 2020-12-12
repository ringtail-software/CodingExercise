## Coding Exercise
**Name:** David Cyphert

**Date:** 12/12/2020

**Assignment: **[Investment Performance Web API](InvestmentPerformanceWebAPI.md#investment-performance-web-api)

#### How To Run The Web API
1. Open the solution file under the InvestmentPerformance.WebApi directory.

2. To run the Web API from your local machine, press the play button in the top toolbar. This will open your default browser to the Swagger UI page as well as a console window for logging purposes.

**NOTE:** I decided to go with a SQLLite database file for simplicity. Realistically this would be connected to a dev/test SQL Server database but I did not want this to have any external dependencies that would require further configuration. Below is the data that can be found inside the **InvestmentPerformance.db** file:

**User Table:**

| UserId (PK)  | FirstName  | LastName  |
| ------------ | ------------ | ------------ |
| 1  | David  | Cyphert  |
| 2  |  Willie | Stargell  |
| 3  | Roberto  |  Clemente |
| 4  | Bill  | Mazeroski  |

**Stocks Table:**

|  TickerSymbol (PK) | CompanyName  | CurrentPrice  |  Open |  PreviousClose | Bid  |  Ask | Volume  |
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
| MSFT  | Microsoft Corporation | 213.26 | 210.05 | 210.52  |  213.05 | 212.96 | 28485071  |
| AMZN | Amazon.com, Inc.  | 3116.42  | 3096.66 | 3101.49  |  3108.54 |  3112.62 |  2940618 |
| AAPL  |  Apple Inc. | 122.41 | 122.43  | 123.24  | 122.17  | 122.19  |  81462378 |
| PFE  | Pfizer Inc.  | 41.12  | 41.97 | 41.73  |  41.27 | 41.29  |  58902778 |

**UserInvestment Table:**

| InvestmentId (PK) |  UserId (FK) |  TickerSymbol (FK) |  ShareCount | CostBasis |  PurchaseDate |
| ------------ | ------------ | ------------ | ------------ | ------------ | ------------ |
|  1 |  1 | MSFT  | 100  | 208.11  |  2020-04-10 00:00:00 |
|  2 |  1 | AMZN  | 50  | 2954.0  |  2020-02-01 00:00:00 |
|  3 |  2 | MSFT  |  25 | 219.11  | 2020-08-17 00:00:00  |
|  4 |  3 | AAPL  | 30  | 63.57  | 2019-03-01 00:00:00  |
| 5 |  4 | MSFT | 500  | 225.11  | 2020-04-24 00:00:00  |
| 6 |  4 | AMZN  | 150  | 2099.11  | 2018-06-13 00:00:00  |

#### How To Run The Unit Tests
1. Right click on the **InvestmentPerformance.WebApi.Tests** project and then Run Tests.

2. This will bring up the Test Explorer window where you can see the tests defined and if they passed/failed.