dotnet restore
dotnet build --no-restore
dotnet stryker -tp tests/PowerUtils.xUnit.Extensions.Tests.csproj --reporter cleartext --reporter html -o