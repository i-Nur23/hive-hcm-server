FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ScrapersService.Main/ScrapersService.Main.csproj", "ScrapersService.Main/"]
COPY ["ScrapersService.Countries/ScrapersService.Countries.csproj", "ScrapersService.Countries/"]
RUN dotnet restore "./ScrapersService.Main/ScrapersService.Main.csproj"
COPY . .
WORKDIR "/src/ScrapersService.Main"
RUN dotnet build "./ScrapersService.Main.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./ScrapersService.Main.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScrapersService.Main.dll"]