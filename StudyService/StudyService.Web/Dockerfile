FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/StudyService/StudyService.Web/StudyService.Web.csproj", "Server/StudyService/StudyService.Web/"]
COPY ["Server/StudyService/StudyService.Application/StudyService.Application.csproj", "Server/StudyService/StudyService.Application/"]
COPY ["Server/StudyService/StudyService.Models/StudyService.Models.csproj", "Server/StudyService/StudyService.Models/"]
COPY ["Server/StudyService/StudyService.Persistence/StudyService.Persistence.csproj", "Server/StudyService/StudyService.Persistence/"]
RUN dotnet restore "Server/StudyService/StudyService.Web/StudyService.Web.csproj"
COPY . .
WORKDIR "/src/Server/StudyService/StudyService.Web"
RUN dotnet build "StudyService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudyService.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudyService.Web.dll"]