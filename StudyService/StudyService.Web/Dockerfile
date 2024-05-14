FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["StudyService.Web/StudyService.Web.csproj", "StudyService.Web/"]
COPY ["StudyService.Application/StudyService.Application.csproj", "StudyService.Application/"]
COPY ["StudyService.Models/StudyService.Models.csproj", "StudyService.Models/"]
COPY ["StudyService.Persistence/StudyService.Persistence.csproj", "StudyService.Persistence/"]
RUN dotnet restore "./StudyService.Web/StudyService.Web.csproj"
COPY . .
WORKDIR "/src/StudyService.Web"
RUN dotnet build "./StudyService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./StudyService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyService.Web.dll"]