FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/EmployeeService/EmployeeService.API/EmployeeService.API.csproj", "Server/EmployeeService/EmployeeService.API/"]
COPY ["Server/EmployeeService/EmployeeService.Application/EmployeeService.Application.csproj", "Server/EmployeeService/EmployeeService.Application/"]
COPY ["Server/EmployeeService/EmployeeService.Persistence/EmployeeService.Persistence.csproj", "Server/EmployeeService/EmployeeService.Persistence/"]
COPY ["Server/EmployeeService/EmployeeService.Models/EmployeeService.Models.csproj", "Server/EmployeeService/EmployeeService.Models/"]
RUN dotnet restore "Server/EmployeeService/EmployeeService.API/EmployeeService.API.csproj"
COPY . .
WORKDIR "/src/Server/EmployeeService/EmployeeService.API"
RUN dotnet build "EmployeeService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeService.API.dll"]