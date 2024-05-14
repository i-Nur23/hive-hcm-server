FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8082
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EmployeeService.API/EmployeeService.API.csproj", "EmployeeService.API/"]
COPY ["EmployeeService.Application/EmployeeService.Application.csproj", "EmployeeService.Application/"]
COPY ["EmployeeService.Persistence/EmployeeService.Persistence.csproj", "EmployeeService.Persistence/"]
COPY ["EmployeeService.Models/EmployeeService.Models.csproj", "EmployeeService.Models/"]
RUN dotnet restore "./EmployeeService.API/EmployeeService.API.csproj"
COPY . .
WORKDIR "/src/EmployeeService.API"
RUN dotnet build "./EmployeeService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./EmployeeService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.API.dll"]