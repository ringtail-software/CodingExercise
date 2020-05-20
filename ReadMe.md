# How to run

This project requires you have a ms-sql-server instance running on your machine.

## Deploying the database with seed data
Change your appsettings.json ConnectionString to point to your ms-sql-server instance, with the disired name of your to-be database.

Go To Package Manager Console inside VS and run this command to ensure you have ef-core

`dotnet tool install --global dotnet-ef`

ensure you're inside the `\Coding\InvestmentPerformance\` folder by checking with `ls` or `dir`
Then run this command to actually publish the database with seed data

`dotnet ef database update`

If you run into any problems here's the [docs](https://docs.microsoft.com/en-us/ef/core/get-started/?tabs=netcore-cli)

Then run the WebServer/IIS Express and test the endpoints with [swagger-ui](https://swagger.io/tools/swagger-ui/)

## Tests
Should be self explanitory.
Right click on the xunit project and click "Run Tests".

## Thank You!
This has been a fun coding experience, looking forward to some feedback/constructive criticism.