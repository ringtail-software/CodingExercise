
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


### ToDo
First thought: If this were a full feature implementation, what would be involved?
 - [x] Create new VS project
 - [x] Add Swagger
 - [ ] Create Investment Service / Model / Tests
	 - [ ] Get investments by user
	 - [ ] Get investment details (by investment id)
 - [ ] Create Investment Controller
 - [ ] Confirm working
 - [ ] Confirm documentation
 - [ ] Add instructions on how to run to Readme.md


### Notes
Swagger config: https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1

