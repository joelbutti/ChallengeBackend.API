FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copia el archivo de proyecto y restaura las dependencias
COPY ChallengeBackend.API/*.csproj ./ChallengeBackend.API/
WORKDIR /app/ChallengeBackend.API
RUN dotnet restore

# Copia el resto de los archivos y construye la aplicación
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o out

# Usa una imagen ligera con el entorno de ejecución de .NET
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Establece el comando para iniciar la aplicación al iniciar el contenedor
ENTRYPOINT ["dotnet", "ChallengeBackend.API.dll"]
