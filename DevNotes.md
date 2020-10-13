
## Michael's Dev Notes
This is just a place for me to jot notes as I'm working on the assignment.

### Approach
My initial temptation was to build a complete app to match the feature request. But the instructions specifically says to create a web API, and that the assignment should only take a couple of hours. As such, I will narrow the scope specifically to controller and service methods. 

For speed, I'll start with a default VS2019 ASP.NET Core Web project with API only.

### Assumptions
Starting assumptions
- Use Swagger as UX
- No DB, mock data in static classes
- Assume authenticated user
- Log to default logger

Additional assumptions
- using ints as Ids, but in a large system it would be guids
- an investment object represents a single transaction of purchasing shares of stock
- there would be an existing authentification system that we would tie into, likely confirming access to methods
- additional assumptions documented in code

### Issues
If this were an actual story, several things would need to be clarified. 
- Terminology: An Investment appears to represent a transaction. But common nominclature might suggest an investment includes all transactions into an entity. Eg: buying stock in the same company at different times.
- If that's the case, do we need to aggreigate it? 
- What does the data look like that the API is grabbing?


### ToDo
First thought: If this were a full feature implementation, what would be involved?
 - [x] Create new VS project
 - [x] Add Swagger
 - [x] Create Investment Service / Model / Tests
	 - [x] Get investments by user
	 - [x] Get investment details (by investment id)
 - [x] Create Investment Controller
 - [x] Confirm app appears working
 - [x] Confirm tests working
 - [x] Confirm documentation
 - [x] Add instructions on how to run to Readme.md


### Notes
Swagger config: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1

