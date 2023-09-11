# Base Image 
FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
# Directory inside Docker filesystem
WORKDIR /app
# Tells Docker to listent to TCP connections
EXPOSE 80

#copy all .csproj files and restore as distinct layers. Use of the same COPY command
# for every dockerfile n the project to take advantage of docker caching

# COPY <file in development machine FROM> <TO directory in workdir in docker>
COPY Carsties.sln Carsties.sln
COPY src/AuctionService/AuctionService.csproj src/AuctionService/AuctionService.csproj
COPY src/SearchService/SearchService.csproj src/SearchService/SearchService.csproj
COPY src/GatewayService/GatewayService.csproj src/GatewayService/GatewayService.csproj
COPY src/BiddingService/BiddingService.csproj src/BiddingService/BiddingService.csproj
COPY src/Contracts/Contracts.csproj src/Contracts/Contracts.csproj
COPY src/IdentityService/IdentityService.csproj src/IdentityService/IdentityService.csproj

# Restore package deps
# because we inside context of dotnet/sdk:7.0 so we have access to dotnet cli
RUN dotnet restore Carsties.sln

# Copy the app folders over
COPY src/BiddingService src/BiddingService
# Because Dependency
COPY src/Contracts src/Contracts
WORKDIR /app/src/BiddingService
RUN dotnet publish -c Release -o /app/src/out

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
# Copy from build stage from /app/src/out directory to current place (/app inside this stage)
COPY --from=build /app/src/out .
ENTRYPOINT [ "dotnet", "BiddingService.dll" ]