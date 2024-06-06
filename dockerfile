# Usar uma imagem base oficial do .NET SDK 8 para buildar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar csproj e restaurar dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o resto dos arquivos e construir a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usar uma imagem base oficial do .NET Runtime 8 para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expor a porta que a aplicação irá rodar
EXPOSE 8080

# Definir o comando de inicialização
ENTRYPOINT ["dotnet", "stock-control-api.dll"]