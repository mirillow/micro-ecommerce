FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY . .

RUN dotnet restore

RUN dotnet publish -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /App
COPY --from=build /App/out .

EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "CartService.Api.dll"]