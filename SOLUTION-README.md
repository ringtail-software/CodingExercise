# Nuix Sample API

This project is based on the task described [here](https://github.com/ringtail-software/CodingExercise/blob/master/InvestmentPerformanceWebAPI.md#investment-performance-web-api).


### Tools
- Visual Studio 2019
    - F5 to run

### Tech Stack

- [ASP.Net Core 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
    - XUnit
    - Moq

- [Docker Desktop for Windows](https://www.docker.com/products/docker-desktop)

To build the image:

```
cd Nuix.Api

docker build -t sample .
```

To run the image:

```
docker run -d --rm -p 29001:9001 sample:latest
```

To test the image: navigate to http://localhost:29001/swagger