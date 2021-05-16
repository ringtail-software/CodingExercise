# Rocchio Investment Performance Web API Setup

#### Database Entities
This API assumes that a user can make purchases on an investment at multiple different times. There are three entities that represent the data.
  1. _Investment_ - This represents an investment that a user can buy shares of at any give time. This holds the current price of the investment.
  2. _UserInvestment_ - This links a user to an investment
  3. _Purchase_ - This represents a purchase by a user of a certain amount of shares of an investment. This holds the cost basis per share at the time of the purchase and the number of shares.

#### Setup and Run Instructions:
This is a .NET Core 3.1 Web API. Authentication for this API uses an Auth0 tenant. For testing, two long-lived access tokens have been generated. One is for an admin user, and one for a non-admin user (see Step 3 below).

##### 1. Run Migrations and set up the data
 - Add a connectionstring to the ConnectionStrings.InvestmentPerformance setting in the appsettings.json file
 - Ensure that you have the Entity Framework Core CLI tools installed (https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
 - Set up the database and seed the initial data by using the `dotnet ef database update` command from the `\InvestmentPerformance.Api` directory

##### 2. Build and run the InvestmentPerformance.Api project

##### 3. Test the API endpoints
- The API will be running on port 5001. There are four endpoints to test.
- The two endpoints on the InvestmentsController will get the data for the authenticated requesting user.
   - https://localhost:5001/investments
   - https://localhost:5001/investments/{investmentId}
- The two endpoints on the UsersController check that the requesting user has an "admin" role. These endpoints allow the user to query for other users' data.
   - https://localhost:5001/users/{userId}/investments
   - https://localhost:5001/users/{userId}/investments/{investmentId}
- **Using Postman:** The preferred method of testing is to use Postman. A Postman collection file has been included in the `\ApiTesting` directory. You can import that collection into  Postman to get six requests to the API (2 for InvestmentsController, 2 for UsersController as Admin, 2 for UsersController as Non-Admin).
- **Not Using Postman:** Two test users have been generated in the Auth0 tenant for this API with long-lived access tokens that would only be used for development testing purposes. Users are authorized using OAuth 2.0 using a generated JWT as a Bearer token. Add the following Bearer tokens in the Authorization request header. One token is valid for an Admin user in the system (can be used to request endpoints on the UsersController), and the other token is valid for a non-Admin user (expect a 403 when making requests to endpoints on the UsersController):
   - _Admin User Token_
   `eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IndkZk9nZ3J6T3BaZkJCN1hMRzNScCJ9.eyJpc3MiOiJodHRwczovL2Rldi1xOHR0NC0yNC51cy5hdXRoMC5jb20vIiwic3ViIjoiTFV3eVN3MkRHbnQ4VElqZnloSnE1YlFhbGVMT2g2U0tAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9udWl4L2FwaSIsImlhdCI6MTYyMTA5MTI5MCwiZXhwIjoxNjIzNjgzMjkwLCJhenAiOiJMVXd5U3cyREdudDhUSWpmeWhKcTViUWFsZUxPaDZTSyIsInNjb3BlIjoiYWRtaW4iLCJndHkiOiJjbGllbnQtY3JlZGVudGlhbHMiLCJwZXJtaXNzaW9ucyI6WyJhZG1pbiJdfQ.QHV8leLImkw-msBpJh_VlBlLbtLdwRRYMlm15lukKH9voijL_dp6MORfP2ETuOBOi39gysDKzmh20fHcRslBbe0rmwNKL5sb0STgWSmywdkUX0do6cBLOMAuOpdqSV_A41icJ-e73XsAHuGSe4J9tplxZ0xkbRvZpMofZQAbkiTvFLhe1SxgOFIyLtef4bXiSeJI6Gg9dKZOjojVa0-LOoYoC8ixLCayMmsiDxCTyFimojkkRFaOyZy6uu4UtkSvnTg5j9bmcbCEeOGc4LWHvEaEl3AO4s7oslC3BYAPmIV-iFKrDmu5XC-dE2x3TuemzfABT8fryc9oex66uLNKtA`

   - _Non-Admin User Token_
   `eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCIsImtpZCI6IndkZk9nZ3J6T3BaZkJCN1hMRzNScCJ9.eyJpc3MiOiJodHRwczovL2Rldi1xOHR0NC0yNC51cy5hdXRoMC5jb20vIiwic3ViIjoic1h5YndRN0phREo4OGp4QWtCcFRSV2VwVUY0d2ZLdmlAY2xpZW50cyIsImF1ZCI6Imh0dHA6Ly9udWl4L2FwaSIsImlhdCI6MTYyMTA5MTM2MSwiZXhwIjoxNjIzNjgzMzYxLCJhenAiOiJzWHlid1E3SmFESjg4anhBa0JwVFJXZXBVRjR3Zkt2aSIsImd0eSI6ImNsaWVudC1jcmVkZW50aWFscyIsInBlcm1pc3Npb25zIjpbXX0.CvZePr-YvmFHS_ttVsmZ_pFQ57rDUnwPJQA-iMxYZCWWjsnzqZ39_Zqku4t-cYLgeRUh6mbehV519j2Vs2RVUhafcM_-uufSfT7rnfGBNrbBMpwWU5GiD7y1C5K13AAsrO2gmubsfnv9mnsSe6_t4NU9qC0bs-nZqMzNLTSZpe1dWWAznPUCXZbd-j4y9ih-PeHg5MjOWXVeBUaT-TE23VTonf46p5bx_KoGUgl8t1L9bakMpiBBdu-lI86SgiqFUjENpqK3zDYibDJXSiEdXOQDCISrVPOCuvVT-cw8Nd8DsujiTgFmTtdLLXitvLDpn8v1V398cF7EKdTLWhg8Mw`