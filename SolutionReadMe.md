#Coding Exercise
Author : Jonathan Carr
Date: Fri Apr 9 2021

###Documentation
[Api Documentation](https://documenter.getpostman.com/view/15262524/TzCTZke8)

###Overview

This WebApi is developed to get investments for a user and get further details on that Investment. WebApi calls are hosted outside of the WebApplication. There are four Projects with the solution
Nuix, RingTail, RingTailStocks, and UnitTests.


- Nuix
  - Nuix is a project for General Functionality across the other projects.
- RingTail
  - RingTail is the project for the actual WebApi Functionality.
- RingTailStocks
  - RingTailStocks is the WebApplication that can be ran locally to see WebApi Calls.
- UnitTests
  - Unit Tests is for running tests for the WebApi project to ensure information is being calculated and returned correctly
###Assumptions
- Api is intended to query for one user at a time
- Api is currently only for fetching Stock details for the user.

###Process for Running

- After downloading the project and opening the solution file in the desired IDE, the user will run the RingTailStocks Project.
- The WebApplication that runs from this project will have a "Welcome Page"
- At the top there will be a Menu item called "Current Investments", this is where the user will be able to access the Current investments for the default user.
- Each Investment within the Current Investment Page will be clickable.
- Clicking the investment will open up the details for that particular investment. 
  - Note: the details page will also have a button in case the user would like to view the raw api out.