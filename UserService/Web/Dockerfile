#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Web/UserService.Web.csproj", "Web/"]
COPY ["UserService.Database/UserService.Persistance.csproj", "UserService.Database/"]
COPY ["UserService.Models/UserService.Models.csproj", "UserService.Models/"]
COPY ["UserService.Services/UserService.Services.csproj", "UserService.Services/"]
RUN dotnet restore "./Web/UserService.Web.csproj"
COPY . .
WORKDIR "/src/Web"
RUN dotnet build "./UserService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UserService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.Web.dll"]