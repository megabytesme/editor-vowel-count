FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY src/VowelCount/VowelCount.csproj src/VowelCount/
WORKDIR /app/src/VowelCount
RUN dotnet restore

WORKDIR /app
COPY src/. ./src
RUN dotnet publish src/VowelCount/VowelCount.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "VowelCount.dll"]

EXPOSE 80
