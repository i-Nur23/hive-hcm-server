FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8083
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MoodService.Web/MoodService.Web.csproj", "MoodService.Web/"]
COPY ["MoodService.Application/MoodService.Application.csproj", "MoodService.Application/"]
COPY ["MoodService.Domain/MoodService.Domain.csproj", "MoodService.Domain/"]
COPY ["MoodService.Persistance/MoodService.Persistance.csproj", "MoodService.Persistance/"]
RUN dotnet restore "./MoodService.Web/MoodService.Web.csproj"
COPY . .
WORKDIR "/src/MoodService.Web"
RUN dotnet build "./MoodService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./MoodService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoodService.Web.dll"]