FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Server/RecruitmentService/RecruitmentService.Web/RecruitmentService.Web.csproj", "Server/RecruitmentService/RecruitmentService.Web/"]
COPY ["Server/RecruitmentService/RecruitmentService.Application/RecruitmentService.Application.csproj", "Server/RecruitmentService/RecruitmentService.Application/"]
COPY ["Server/RecruitmentService/RecruitmentService.Domain/RecruitmentService.Domain.csproj", "Server/RecruitmentService/RecruitmentService.Domain/"]
COPY ["Server/RecruitmentService/RecruitmentService.Persistance/RecruitmentService.Persistance.csproj", "Server/RecruitmentService/RecruitmentService.Persistance/"]
RUN dotnet restore "Server/RecruitmentService/RecruitmentService.Web/RecruitmentService.Web.csproj"
COPY . .
WORKDIR "/src/Server/RecruitmentService/RecruitmentService.Web"
RUN dotnet build "RecruitmentService.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RecruitmentService.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitmentService.Web.dll"]