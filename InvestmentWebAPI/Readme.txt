=============
How to run:
=============
- Please open the solution "InvestmentWebAPI\Investment.sln" in Visual Studio 2019 and build the project.
- Run in debug mode
- Open PostMan and import the collection "PostMan Collections\HTTP InvestmentApiCollection.postman_collection" for HTTP calls
- Or import the collection "PostMan Collections\HTTPS InvestmentApiCollection.postman_collection" for HTTPS calls
             NOTE - If using HTTPS, PostMan might prompt you to ignore the SSL Cert. Obviously you have to say yes, and ignore the cert.

=============
Assumptions:
=============
- I created 3 main classes:
	1) Users - Contains an id, username (which is a GUID), FirstName, LastName, and a collection of Investments.
	2) Investments - This is historical data, purchase date, purchase price, and it maps to a Security object
	3) Securities - This class is meant for current price, symbol, and full name.

- I left HTTP and HTTPS enabled. Normally I would redirect HTTP requests to HTTP but, sometimes people have issues with getting HTTPS to work locally, so I left both enabled.
- Persistant database seeding:
	- Each time the code is ran, the database is wiped and then the data is seeded again. Obviously the code could be modified to prevent this
		1) Comment out or remove line 24: "context.Database.EnsureDeleted();" from Program.cs
		2) Comment out or remove line 35: "SeedDatabase(host);" from Program.cs
- I created a static helper class to help with the Long / Short term. This is in the Helpers folder.
- Obviously it is not a good idea to expose your entities directly to the web api, so I created Models and mapped them upsing AutoMapper.
- The AutoMapper Profiles are in the Profiles class, which is in the Profiles folder. This is kind of where all of the magic happens.
- I created a few extra Web API methods to help assist me with debugging and ensuring my code was accurate.
	1) /api/users - This shows a list of all of the users
	2) /api/securities - This shows a list of all of the securities
	3) /api/investments - This shows a list of all of the investments
- In my mind, while users had investments, there was no need to specificly tie the Investments Details Web API URI call to an individual user.
	- I decided to make the URI /api/investments/{investmentId}.

This was a great, fun, and realistic challenge! Thank you for considering me! Cheers!