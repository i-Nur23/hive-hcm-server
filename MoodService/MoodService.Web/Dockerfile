FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/MoodService/MoodService.Web/MoodService.Web.csproj", "Server/MoodService/MoodService.Web/"]
COPY ["Server/MoodService/MoodService.Application/MoodService.Application.csproj", "Server/MoodService/MoodService.Application/"]
COPY ["Server/MoodService/MoodService.Domain/MoodService.Domain.csproj", "Server/MoodService/MoodService.Domain/"]
COPY ["Server/MoodService/MoodService.Persistance/MoodService.Persistance.csproj", "Server/MoodService/MoodService.Persistance/"]
RUN dotnet restore "Server/MoodService/MoodService.Web/MoodService.Web.csproj"
COPY . .
WORKDIR "/src/Server/MoodService/MoodService.Web"
RUN dotnet build "MoodService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoodService.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoodService.Web.dll"]