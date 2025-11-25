# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["GlobalSolution.API/GlobalSolution.API.csproj", "GlobalSolution.API/"]
RUN dotnet restore "GlobalSolution.API/GlobalSolution.API.csproj"

# Copy source code and build
COPY . .
WORKDIR "/src/GlobalSolution.API"
RUN dotnet build "GlobalSolution.API.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "GlobalSolution.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlobalSolution.API.dll"]
