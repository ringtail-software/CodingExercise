### Investment Performance Web API

This is a working Web API
The build contains commands to run the app in Linux or in Windows environment.

## Assumptions
I didn't embed any database engine, instead I used `json` files to store locally (in the `resources` folder) the data. 
In the code, I provided SQL statement examples that can be used if a database connection is required.
The code is structured in layers so moving from one source of data to another one should be easy.
I provided a set of unit-tests to cover some coding aspects. In a production ready code the number of unittests should be significantly greater and should cover all the service and manager layers public and protected classes.
I also covered some code with try and catch blocks and I thrown some exceptions.

I know that making sure the code is stable is important, but I assumed that this coding exercise is meant to provide a general idea about coding techniques, so please consider that I am aware that many more try/catch blocks are needed, and also a larger set of specialized exceptions are needed.  

Note: the project is written in Scala with gradle as builder and automation helper.

## Build
Linux
 - ./gradlew clean build
 
Windows
 - gradlew.bat clean build
 
## Run the unit tests
Linux
  - ./gradlew test

Windows
  - gradlew.bat test
  
## Start the server
1. Prerequisite: have the `Build` step executed. The compressed packages will be prepared in `build/distributions` directory.
2. Open one terminal window (also prepare another terminal window to execute the API calls)
3. Navigate to `build/distributions` and select the `tar` or the `zip` file, whichever is more convenient to work with
4. In a working directory (folder) of your choice unpack the distribution package.
5. cd `trading`
6. cd `bin`
7. Execute `./trading` in Linux or `trading.bat` in Windows
8. Leave the terminal open

## Test the Web API
1. In a new terminal window execute (curl examples):
  - Make sure that the server is up and running (no port conflicts)
    ```
      curl -k -X GET  https://localhost:8383/trading/ping
    ```
    the response should be simply: `pong`
  - Get a list of current investments for the user
    ```
      curl -k -X GET  https://localhost:8383/trading/investment?username=johnone
    ```
    the response should be:
    ```
    {
       "111": "one",
       "222":"two"
    }
    ```
  - Get details for a user's investment
    ```
      curl -k -X GET  https://localhost:8383/trading/investment/111
    ```
    the response should be:
    ```
    {
      "investment_id": "111",
      "number_of_shares": 123,
      "cost_basis_per_share": 2.09,
      "current_value": 137.76000000000002,
      "current_price": 1.12,
      "term": "short",
      "total_gain_loss": -119.31
    }
    ```
  - Check the log statements in the `trading.log` file
  
  Note: In the above examples the responses are prettified. In reality, they are retrieved in a compact format.

## Other tools
1. Get the package dependencies
  - ./gradlew dependencies
2. Get the gradle available tasks
  - ./gradlew tasks

Note: Use gradlew.bat in Windows


August-04, 2020
Tibor Dumitriu
