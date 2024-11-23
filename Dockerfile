FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

COPY src/VowelCount.csproj ./
RUN dotnet restore

COPY src/. ./src
WORKDIR /app/src
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "VowelCount.dll"]

EXPOSE 80
