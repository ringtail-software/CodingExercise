Overview
========

Technology used: Python (language), Twisted and Klein (networking,
web, database access libraries), SQLite. I've used each of the
technologies in a professional context in the past and have chosen
them based on my own positive experiences developing production
applications, I'm using them here in the interest of time and
availability. I would rather demonstrate a proficiency with
technologies I know and have available than give you, reviewer, the
wrong impression using unfamiliar libraries and frameworks. I'm happy
to discuss these or any other points should you have any questions.

The API is REST-inspired; due to the limited functionality of the
requirements there are only two endpoints:

User investment listing
-----------------------

Available under `/user/<USER ID>/investments`, with a JSON response such
as:

```
[
    {
        "id": 1,
        "name": "American Express Co."
    },
    {
        "id": 2,
        "name": "American Express Co."
    },
    {
        "id": 3,
        "name": "Amazon.com Inc."
    }
]

```

Per Investment Summary
----------------------

Available under `/user/<USER ID>/investments/<INVESTMENT ID>`, with a
JSON response such as:

```
{
    "costBasis": 9060,
    "currentPrice": 9560,
    "currentValue": 76480,
    "gainLoss": 500,
    "numberOfShares": 8,
    "term": "short"
}
```

Example Endpoints
-----------------

With the data preloaded in the example container, the following user IDs
exist:

-   1
-   2
-   3

Of those, only user ID 1 has corresponding Investments, with IDs:

-   1
-   2
-   3

The specific placeholder data is loaded as part of `sample-data.sql`,
should you wish to peruse it.

A Note on Users
---------------

The requirements did not call for user authentication or authorization,
which would normally be the first feature of such a system. In sticking
closely to the requirements and with limited time I have not included
either with the understanding that, in the examples above, where a USER
ID is called for, another service or middleware would authenticate
requests first and then authorize the requested resources.

Schemas
-------

The database schema was laid out with the following in mind.

-   Accounts are not fully addressed for the previously mentioned
    reasons, here they contain only an ID lookup, unlike any real-world
    system.
-   Financial instruments are recorded in an append-only fashion, where
    each entry correlates a company, timestamp and price. This was
    designed with the idea that features such as \"portfolio
    performance\" are typical of investment performance and an
    append-only log of price information is a simple realization of the
    idea.
-   Money should be tracked with only decimal numbers. In the Instrument
    table I have used integers, where a necessary exchange into
    application code is necessary a Decimal type would be necessary to
    prevent floating point errors creeping in. In the example data I
    have pre-populated I created some random data and then multiplied by
    100, as if the system were tracking per-cent rather than per-dollar.
    Such a decision would change with different currencies etc.

A Note on Python Programming
----------------------------

For those reviewers unfamiliar with Python programming, one bit of
idiomatic Python that is often distasteful to users of other languages
is the use of exceptions for control flow. An example of this can be
seen in the database interaction layer where non-existent records
trigger a `NotFound` exception. In most other languages this would
likely be a sentinel value instead and be handled more directly, rather
than raising through the call stack to an exception handler within
`_service.py`.

Running
=======

Included is a Dockerfile that wraps the operating environment and
necessary dependencies. Also included is a tiny sample of data
prepopulated inside a sqlite database for demonstration purposes.

The container is intended to save reviewers from having to configure a
Python development environment. Production containers would not have
shared responsibility for application code and data. Most production use
cases would package application code within the container and share a
network interface over which to communicate with a database server
(which does not exist in this example).

The webserver is configured to default to port 8080 within the
container, below is an example of building and running the container
using port 8080 on the host machine:

```
$ podman build -f example.dockerfile --tag performance-api-demo

STEP 1: FROM python:3
STEP 2: RUN python -m venv /opt/venv-python
--> Using cache c1b92fdda8ba15b3244452f7112fc39be21ab65684770bc6b3dfdb2c660142e1
STEP 3: COPY . /code
--> 3d9098cb02f
STEP 4: RUN /opt/venv-python/bin/pip install /code
Processing /code
...
--> 63dcc40f7d3
STEP 5: FROM python:3-slim
STEP 6: COPY --from=0 /opt/venv-python /opt/venv-python
--> a2217667738
STEP 7: COPY schema.sql /data/schema.sql
--> cef9efa31f5
STEP 8: COPY sample-data.sql /data/sample-data.sql
--> 1d085680334
STEP 9: RUN apt update && apt install sqlite3
...
--> d4a75ddc61c
STEP 10: RUN cat /data/schema.sql /data/sample-data.sql | sqlite3 /data/test.db
--> c77a0a506fc
STEP 11: ENTRYPOINT ["/opt/venv-python/bin/twist", "performance-api", "-d", "/data/test.db"]
STEP 12: COMMIT performance-api-demo
--> 2d7032bddfe
2d7032bddfe1f375e1b5b6233e777af3ae9634460f24db46c04bf560604a4fcf

$ podman run -p 8080:8080/tcp -it localhost/performance-api-demo
...
```

Development
===========

Installation
------------

The Python ecosystem has traditionally used \"virtual environments\" to
isolate dependencies and standardize paths. Setting one up with a modern
(i.e. Python 3) installation can be accomplished as such:

```
$ git clone ... && cd
$ python3 -m venv development-env
$ ./development-env/bin/pip install -e .
```

The result is an \"editable\" installation which will automatically
update as changes are made to the project.

Testing
-------

The unit tests are runnable via the `trial` test runner, which is
packaged with the Twisted framework and will be installed via `pip` in
the previous installation step.

```
$ ./development-env/bin/trial performance_api
performance_api.test.test_service
  PerformanceApiTests
    test_investments_listing ...                                           [OK]
    test_investments_listing_empty_result_json ...                         [OK]
    test_investments_listing_empty_result_response_code ...                [OK]
    test_investments_listing_no_such_account ...                           [OK]
    test_investments_listing_response_code ...                             [OK]
    test_investments_listing_result_json ...                               [OK]
    test_investments_summary_no_such_investment_response_code ...          [OK]
    test_investments_summary_response_code ...                             [OK]
    test_investments_summary_result_json ...                               [OK]
    test_request_root ...                                                  [OK]

-------------------------------------------------------------------------------
Ran 10 tests in 0.037s

PASSED (successes=10)
```
