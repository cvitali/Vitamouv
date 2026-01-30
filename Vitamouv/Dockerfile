# Étape 1 : Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copier uniquement le fichier csproj d'abord (optimisation du cache)
COPY Vitamouv/Vitamouv.csproj ./Vitamouv/
WORKDIR /src/Vitamouv
RUN dotnet restore

# Copier le reste du projet
WORKDIR /src
COPY . .

# Compiler en mode Release
WORKDIR /src/Vitamouv
RUN dotnet publish -c Release -o /app

# Étape 2 : Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copier les fichiers compilés
COPY --from=build /app .

# Render utilise le port 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# Lancer l'application
ENTRYPOINT ["dotnet", "Vitamouv.dll"]
