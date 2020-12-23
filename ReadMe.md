# Zach Albert's Coding Exercise 12/22/2020

Investment Performance Api

#Notes
I tried to add a SQLite database to be able to had actual data in the system, but was unable to get it running.  You can see my effore in the InvestmentDal class and the WebApiConfig
Written in Visual Studio with .Net Framework, AutoFac, and NUnit

#How To Run
Open in visual studio and run with IIS Express

To query the UserInvestments update the URL to http://localhost:<port number>/api/Investment/RetrieveUserInvestments/1

To query the UserInvestmentDetails update the URL to http://localhost:<port number>/api/Investment/RetrieveUserInvestmentDetails/1/1

To Run UnitTests right click the project and select "Run Unit Tests"


