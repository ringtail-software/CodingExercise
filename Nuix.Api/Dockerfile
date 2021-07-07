FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "/src/Nuix.Api.sln"
RUN dotnet build "/src/Nuix.Api.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/src/Nuix.Api.sln" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS "http://+:9001"
#ENV ASPNETCORE_ENVIRONMENT "Docker"
ENV ASPNETCORE_ENVIRONMENT "Development"
ENTRYPOINT ["dotnet", "Nuix.Api.dll"]