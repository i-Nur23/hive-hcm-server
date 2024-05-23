FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/ScrapersService/ScrapersService.Main/ScrapersService.Main.csproj", "Server/ScrapersService/ScrapersService.Main/"]
COPY ["Server/ScrapersService/ScrapersService.Countries/ScrapersService.Countries.csproj", "Server/ScrapersService/ScrapersService.Countries/"]
RUN dotnet restore "Server/ScrapersService/ScrapersService.Main/ScrapersService.Main.csproj"
COPY . .
WORKDIR "/src/Server/ScrapersService/ScrapersService.Main"
RUN dotnet build "ScrapersService.Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ScrapersService.Main.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ScrapersService.Main.dll"]