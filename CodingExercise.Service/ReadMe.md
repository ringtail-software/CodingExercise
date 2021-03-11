# Investment Performance Web API
## Code Exercise
##### Submitted by Isaac Hammon

This solution was built in .Net Core 3.1 using Visual Studio 2019. The CodingExercise.Service is the main project and the CodingExercise.Tests project contains the unit tests. The main project can be run in Visual Studio or from the command line using the command:
>dotnet run

from the main project folder. The service binds http://localhost:5000/ by default which contains the swagger documentation. Limited logging is included using nlog. The log file location can be found in the appsettings.json file. A json file was used to store data instead of a database due to time constraints. The json file can be found at CodingExercise.Service/data.json. The web api can be called from the browser, a tool like Postman, or from the swagger page while the project is running. An example call is 
>http://localhost:5000/api/Investment/1.