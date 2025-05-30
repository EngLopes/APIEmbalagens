FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore APIEmbalagens.sln
RUN dotnet build APIEmbalagens.sln -c Release
RUN dotnet test APIEmbalagens.sln -c Release --no-build
RUN dotnet publish APIEmbalagens.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "APIEmbalagens.dll"]
