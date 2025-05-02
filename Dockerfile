# Usa la imagen oficial de .NET SDK para compilar
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia los archivos de tu proyecto
COPY . ./

# Restaura las dependencias
RUN dotnet restore

# Publica el proyecto
RUN dotnet publish -c Release -o out

# Usa la imagen runtime para correr la app
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto 80
EXPOSE 80

# Comando para iniciar la app
ENTRYPOINT ["dotnet", "SistemaAdopcionMascotas.dll"]
