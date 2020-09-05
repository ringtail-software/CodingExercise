# Investment Trading Platform

The `Investment Trading Platform` provides a set of API's that return data for investment performance. There are 2 API's provided in this release. Both API's are implemented as micro-service in Java useing Spring Boot. Client access is achieved via web requests and the payloads are all returned via HTTP as JSON.

* `InvestmentPerformanceApi`
* `UserApi`



## `InvestmentPerformanceApi`

The `InvestmentPerformanceApi`'s goal is to return data for individual user's investment performance.  This release provides the following functionality.

### Get a list of current investments for a user

Given a `user-id` return a list of all of their investments. The list will include:

* `investment-id`
* `investment-name` Here we will use the company name

#### Sample Request/Response

##### Request

```
GET /api/investments/<user-id>
```

Where _user-id_ is the `id` of the user in the database (can be obtained from the `UserApi`)

##### Response

```json
[
    {
        "id": 325,
        "name": "Facebook"
    },
    {
        "id": 326,
        "name": "Netflix"
    },
    {
        "id": 327,
        "name": "Netflix"
    },
    {
        "id": 328,
        "name": "Uber"
    },
    {
        "id": 329,
        "name": "Amazon"
    },
    {
        "id": 330,
        "name": "IBM"
    },
    {
        "id": 331,
        "name": "IBM"
    },
    {
        "id": 332,
        "name": "Google"
    },
    {
        "id": 333,
        "name": "Cisco Systems"
    },
    {
        "id": 334,
        "name": "Microsoft"
    },
    {
        "id": 335,
        "name": "IBM"
    },
    {
        "id": 336,
        "name": "Apple"
    },
    {
        "id": 337,
        "name": "Google"
    },
    {
        "id": 338,
        "name": "Square"
    },
    {
        "id": 339,
        "name": "Square"
    },
    {
        "id": 340,
        "name": "Intel"
    },
    {
        "id": 341,
        "name": "Microsoft"
    },
    {
        "id": 342,
        "name": "Google"
    },
    {
        "id": 343,
        "name": "Cisco Systems"
    },
    {
        "id": 344,
        "name": "Google"
    },
    {
        "id": 345,
        "name": "Square"
    }
]
```



### Get a list of current investments for a user

Given a user's `investment-id` return a list of details for that investment. The data returned contains:

* `number-of-shares`
* `cost-basis-per-share` is the price of a single share at the time of purchase.
* `current-price` is the current price of a single share.
* `current-value` is the total value of the shares. The `number-of-shares * current-price`
* `term` is the length of ownership of the investment. One year or less is considered "SHORT_TERM". Greater than one year is considered "LONG_TERM".
* `total-loss-or-gain` is the difference between the `current-value` and the value of the stocks when they were purchased.

#### Sample Request/Response

##### Request

```
GET /api/investment-detail/<investment-id>
```

Where _investment-id_ is the `id` of the investment in the database (obtained from `/api/investments/<user-id>`)

##### Response

```json
{
    "numberOfShares": 3634,
    "costBasisPerShare": 10.41,
    "currentPrice": 10.99,
    "currentValue": 39937.66,
    "term": "LONG_TERM",
    "totalLossOrGain": 2107.72
}
```



## `UserApi`

The `UserApi`'s goal is to return data for investors in the `Investment Trading Platform`.

**Note:** This API was not in the problem description but I added it as a convenience for manual testing. It was easier to use this to do a quick listing of users--to then test the `InvestmentPerformanceApi`-- than query the database directly.

This release provides the following functionality.

### Get a list of users on the system

 The users api needs no input and returns a list of all investors on the system. The list will include:

* `user-id`
* `first-name`
* `last-name`
* `email`

#### Sample Request/Response

##### Request

```
GET /api/users
```

##### Response

```json
[
    {
        "id": 1,
        "firstName": "Charles",
        "lastName": "Burns",
        "email": "cmburns@springfieldnuclear.org"
    },
    {
        "id": 2,
        "firstName": "Tywin",
        "lastName": "Lannister",
        "email": "lord.paramount@lannister.com"
    },
    {
        "id": 3,
        "firstName": "Tony",
        "lastName": "Stark",
        "email": "tony@stark.com"
    },
    {
        "id": 4,
        "firstName": "Bruce",
        "lastName": "Wayne",
        "email": "bruce.wayne@wayne-enterprises.com"
    }
]
```



# Design Considerations

* Each investment is it's own single transaction so there will not be groups of shares with different _cost bases per-share_ and _term_'s inside a single investment.
* An external service would be required to get a stock's current price so I will either be mocking the service or building the functionality into the business logic via some stub class/service.



# Building the Investment Trading Platform

## Database installation and setup

The `Investment Trading Platform` requires a database for storing user and investment data. The following document describes the setup of that aspect of the application

[Database Setup](database-setup.md)

## Java 14 / Spring Boot application

The application uses `maven` as the build system but comes with a maven loader script that should download the appropriate maven libaries required for building. Maven in turn will download all of the dependencies required for building and running the application.

However a Java 14 SDK is required and must be installed for the application to build properly.

Also if you already have your own installation of Maven installed you can use that instead of the maven script provided with the application; just substitute your maven command for the script location.

### Building the Investment Trading Platform (ITP)

```bash
mvn clean package
```

### Testing ITP

```bash
mvn test
```

### Running ITP

* Run from `maven`

```bash
mvn spring-boot:run
```

* Run from command line. After you have succesfully run the `mvn package` an executable JAR file will have been created in the `/target` folder with a name like `InvestigateTradingPlatform-0.1.1-SNAPSHOT.jar` or instead of `0.1.1-SNAPSHOT` whichever version was used in the applications `pom.xml` file at the time it was built. This JAR file is also known as a "fat jar" file meaning it contains all of the required dependencies needed to run the application along with the compiled Java classes produced when building it. It can be run form the command line:

```bash
java -jar ./target/InvestigateTradingPlatform-0.1.1-SNAPSHOT.jar
```

Once the application is run either of the above ways it starts the embedded **Tomcat** web server and after initializes will be ready to handle API requests on port 8080.