#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["api/ACD.Api/ACD.Api.csproj", "api/ACD.Api/"]
COPY ["src/ACD.Domain/ACD.Domain.csproj", "src/ACD.Domain/"]
COPY ["src/ACD.Infrastructure/ACD.Infrastructure.csproj", "src/ACD.Infrastructure/"]
RUN dotnet restore "api/ACD.Api/ACD.Api.csproj"
COPY . .
WORKDIR "/src/api/ACD.Api"
RUN dotnet build "ACD.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ACD.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ACD.Api.dll"]