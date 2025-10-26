# STAGE 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./HomeManagement/
RUN dotnet restore ./HomeManagement/HomeManagement.csproj

# Copy the rest of the code
COPY /. ./HomeManagement/
WORKDIR /app/HomeManagement

# Build
RUN dotnet publish -c Release -o out

# STAGE 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/HomeManagement/out ./
ENTRYPOINT ["dotnet", "HomeManagement.dll"]
