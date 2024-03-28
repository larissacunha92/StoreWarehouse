#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["StoreWarehouse.API/StoreWarehouse.API.csproj", "StoreWarehouse.API/"]
COPY ["StoreWarehouse.Application/StoreWarehouse.Application.csproj", "StoreWarehouse.Application/"]
COPY ["StoreWarehouse.Worker/StoreWarehouse.Worker.csproj", "StoreWarehouse.Worker/"]
COPY ["StoreWarehouse.Domain/StoreWarehouse.Domain.csproj", "StoreWarehouse.Domain/"]
COPY ["StoreWarehouse.Infra.CrossCutting.IoC/StoreWarehouse.Infra.CrossCutting.IoC.csproj", "StoreWarehouse.Infra.CrossCutting.IoC/"]
COPY ["StoreWarehouse.Infra/StoreWarehouse.Infra.csproj", "StoreWarehouse.Infra/"]
RUN dotnet restore "StoreWarehouse.API/StoreWarehouse.API.csproj"
COPY . .
WORKDIR "/src/StoreWarehouse.API"
RUN dotnet build "StoreWarehouse.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StoreWarehouse.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StoreWarehouse.API.dll"]