# # Define a imagem base para compilar o projeto
# FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
# WORKDIR /app
 
# # Copia o arquivo do projeto e restaura as depend�ncias
# COPY ../*.csproj ./
# RUN dotnet restore
 
# # Copia o restante do c�digo-fonte e compila a aplica��o
# COPY . ./
# RUN dotnet publish -c Release -o out
 
# # Define a imagem base para executar a aplica��o
# FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
# WORKDIR /app
 
# # Copia os arquivos compilados da etapa anterior
# COPY --from=build /app/out ./
 
# # Define o comando de inicializa��o da aplica��o
# ENTRYPOINT ["dotnet", "StoreWarehouse.API.dll"]



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