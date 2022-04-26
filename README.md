# Pitak API

Pitak Management API

## Setup

Use SQL Server container instead of installing it locally

```bash
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Your_password123' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest
```
Run the application
```bash
dotnet run --project .\src\WebAPI\WebAPI.csproj
```