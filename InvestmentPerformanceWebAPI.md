# Investment Performance Web API

## General instructions:
Please fork this project and submit a pull request when completed.  You should submit a working piece of software that is tested and can be run.  We will review your pull request and execute your code, please provide instructions on how to do so.

Please keep in mind that this exercise is intended to be achievable in a couple of hours.  We expect a production ready submission that demonstrates not only the code you write but quality controls such as exception handling, logging, unit tests, etc.  Assume that this api will be part of a larger system.  If there are larger considerations, that would have affected decisions of what is in/out of scope, please make note of your assumptions.  The majority of the tech stack in use at Nuix Discover is SQLServer, C#.NET, ExtJs, Vue.js.  We prefer the use of that stack, but we want you to showcase your abilities.  If you don't know those specific technologies, you can substitute.



## Problem statement
The company you are working for is building an investment trading platform for stock, bond and mutual funds.  The platform will have various functionality to buy, sell, deposit, withdrawal, and report on investments.  For this part of the product, they need you to create a web api to return data for investment performance.  The type of api to create is your decision, but it must be hosted on a webserver and accessed via web request.

## Problem details/user stories:
- ### Get a list of current investments for the user 

    As an API user, I want to be able to query the list of investments for a user.  The query should return the investment id and name.

- ### Get details for a user's investment: 

    As an API user, I want to be able to query the details of a specific investment for a user.  The query should return number of shares, cost basis per share, current value, current price, term, and total gain/loss.

#### Definitions:

- Cost basis per share: this is the price of 1 share of stock at the time it was purchased

- Current value: this is the number of shares multiplied by the current price per share

- Current price: this is the current price of 1 share of the stock

- Term: this is how long the stock has been owned.  <=1 year is short term, >1 year is long term

- Total gain or loss: this is the difference between the current value, and the amount paid for all shares when they were purchased

#### Setup and Run Instructions:
This is a.NET Core 3.1 Web API. Authentication for this API uses an Auth0 tenant. For testing, a long-lived access token has been generated (see Step 3 below).

##### 1. Run Migrations and set up the data
 - Add a connectionstring to the ConnectionStrings.InvestmentPerformance setting in the appsettings.json file
 - Ensure that you have the Entity Framework Core CLI tools installed (https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
 - Set up the database and seed the initial data by using the `dotnet ef database update` command from the `\InvestmentPerformance.Api` directory

##### 2. Build and run the InvestmentPerformance.Api project

##### 3. Test the API endpoints
 - The API will be running on port 5001. The two endpoints to test are
    - https://localhost:5001/investments
    - https://localhost:5001/investments/{investmentId}
 - **Using Postman:** The preferred method of testing is to use Postman. A Postman collection file has been included in the `\ApiTesting` directory. You can import that collection into  Postman to get the two requests to the API.
 - **Not Using Postman:** A test user has been generated in the Auth0 tenant for this API with a long-lived access token that would only be used for development testing purposes like this. Users are authorized using OAuth 2.0 using a generated JWT as a Bearer token. Add the following Bearer token in the Authorization request header:
    `eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IndkZk9nZ3J6T3BaZkJCN1hMRzNScCJ9.eyJpc3MiOiJodHRwczovL2Rldi1xOHR0NC0yNC51cy5hdXRoMC5jb20vIiwic3ViIjoic1h5YndRN0phREo4OGp4QWtCcFRSV2VwVUY0d2ZLdmlAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9udWl4L2FwaSIsImlhdCI6MTYyMDQ4OTU5NSwiZXhwIjoxNjIzMDgxNTk1LCJhenAiOiJzWHlid1E3SmFESjg4anhBa0JwVFJXZXBVRjR3Zkt2aSIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyJ9.oIPv_iYfAT39Yq1tYEQg4LD5E4fRVaxODiSvhehX7FjKhIJ58fqfc2Cu4_zI8OxrWk0uTsr3CBecusBKqMLefhhopxjRY4M4pEwUDhJodVUlIg3-h_6kWNWOemhcH2nYYtRJrsa9LPiaak7dItYXfJZT8Oevnm1qiSx0i2uQAm_LmOxQZBkqWwHGjSzMatTraTtcpU3f_ooRMTHEQ76ixNvKPnafeydHY2-KNQytbro4kloBFFV71M5CNjxaRmBGYTj_j9rNtzTBtUPcG2ZSMsVznA0x-RdqHImc0I5WU0IGrvLGIaZKBHGtrcuQFsmzW6Aq18pq-__xhWZ0tBNdxw`





