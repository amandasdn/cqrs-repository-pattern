# Use the official ASP.NET Core runtime image for Linux
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Use the .NET SDK image for Linux
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the csproj and restore as distinct layers
COPY ["BookCatalog/BookCatalog.Api/BookCatalog.Api.csproj", "BookCatalog/BookCatalog.Api/"]
RUN dotnet restore "BookCatalog/BookCatalog.Api/BookCatalog.Api.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/BookCatalog/BookCatalog.Api"
RUN dotnet build "BookCatalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "BookCatalog.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Use the final base image for production
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookCatalog.Api.dll"]
