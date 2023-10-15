# Use a imagem oficial do SDK .NET 7 para compilar o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY . ./

# Publicar o aplicativo
RUN dotnet publish -c Release -o out

# Criar uma imagem final leve
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=build /app/out ./

# Iniciar o aplicativo
ENTRYPOINT ["dotnet", "picpay.dll"]
