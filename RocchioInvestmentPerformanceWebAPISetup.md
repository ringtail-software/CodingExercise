# Rocchio Investment Performance Web API Setup

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