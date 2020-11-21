# Coding Exercise Notes
Polina Hristozova - Investment Performance Web Api

## Description
The entire project is in one Visual Studio Solution. It uses C#, and jQuery and is based on the ASP.MVC.Net framework
There are 2 projects - 
 - InvPerfWebApi - an ASP.MVC.Net project, including the UI, Controllers and Data
 - InvPerfWebApi.Tests - a test project, testing the View and the Data methods.
 
## How to start the project?
 In Visual Studio, start the InvPerfWebApi project. It will open a browser window with some basic ASP.NET information. Go to the menu at the top line across and click on the "User Investments" link. This will open the page with the investments. There are 2 tables:
 - list of user investments
 - list of the performance data for the user investments
 
 It might be necessary to refresh the Nuget packages first. I did not include any binaries in the repository.
 
## How to run the tests?
 Right click on the project file and select Run Tests
 
  
## Additional comments

### InvPerformanceController.cs
    //The api controller was intended for use by the Vue application. In the interest of time I did not finish this path, since 
    //I ran into a cors issue and I have not used Vue much. After I submit this project, I will spend some time to figure out the issue.
    //The methods can be tested in a browser:
    //https://localhost:44340/api/InvPerformance/?userName=User1
    //https://localhost:44340/api/InvPerformance/?userName=User1&investmentName=Investment1
	
### InvestmentDataProvider.cs
	//The data model is flat for simplicity. I am also generating the data randomly. The data generator needs some work to 
    //be able to generate multiple rows for the same user or investment. Currently it creates 10 unique users and 10 unique investments
    //I also made async methods just as a demo. Ideally the methods should be async all the way to the data layer including, 
	//but the data model is very simple and does not have asyncronous behavior.

### HomeController.cs
	//For simplicity I am utilizing the out of the box ASP.MVC.Net example and added my view to the Home controller. The method GetUserInvestmentDataAsync loads the view. 
	//The Home controller is a model controller. The view model is in InvestmentDataViewModel.cs
