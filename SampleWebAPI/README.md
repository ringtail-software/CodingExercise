# Reichert: Investment Performance Web API

## Launch
This solution can be run in debug mode, and web API calls can be entered relative to localhost URL.
All data is returned in JSON format.

### Available API calls:
#### client/list
- This is the default route for the project. It will return all current clients.
#### client/investment/list/{ClientId}
- Returns all of the investments for the client with Id = {ClientId}
#### client/investment/detail/{InvestmentId}
- Returns the investment details for the investment with Id = {InvestmentId}
#### client/investment/analysis/{InvestmentId}
- Returns the analysis of investment where Id = {InvestmentId}

## Notes
- Database calls are simulated by file reads to local project file SampleDbProject.json.
- Stock gains and losses are calculated with a random margin, so successive calls will yield different results.




