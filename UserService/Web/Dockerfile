FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/UserService/Web/UserService.Web.csproj", "Server/UserService/Web/"]
COPY ["Server/UserService/UserService.Database/UserService.Persistance.csproj", "Server/UserService/UserService.Database/"]
COPY ["Server/UserService/UserService.Models/UserService.Models.csproj", "Server/UserService/UserService.Models/"]
COPY ["Server/UserService/UserService.Services/UserService.Services.csproj", "Server/UserService/UserService.Services/"]
RUN dotnet restore "Server/UserService/Web/UserService.Web.csproj"
COPY . .
WORKDIR "/src/Server/UserService/Web"
RUN dotnet build "UserService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserService.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserService.Web.dll"]