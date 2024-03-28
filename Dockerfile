FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
 
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StoreWarehouse.API/StoreWarehouse.API.csproj", "StoreWarehouse.API/"]
RUN dotnet restore "StoreWarehouse.API/StoreWarehouse.API.csproj"
COPY . .
WORKDIR "StoreWarehouse.API"
RUN dotnet build "StoreWarehouse.API.csproj" -c Release -o /app/build
 
FROM build AS publish
RUN dotnet publish "StoreWarehouse.API.csproj" -c Release -o /app/publish
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreWarehouse.API.dll"]