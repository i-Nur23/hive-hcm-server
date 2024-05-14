FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8081
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RecruitmentService.Web/RecruitmentService.Web.csproj", "RecruitmentService.Web/"]
COPY ["RecruitmentService.Application/RecruitmentService.Application.csproj", "RecruitmentService.Application/"]
COPY ["RecruitmentService.Domain/RecruitmentService.Domain.csproj", "RecruitmentService.Domain/"]
COPY ["RecruitmentService.Persistance/RecruitmentService.Persistance.csproj", "RecruitmentService.Persistance/"]
RUN dotnet restore "./RecruitmentService.Web/RecruitmentService.Web.csproj"
COPY . .
WORKDIR "/src/RecruitmentService.Web"
RUN dotnet build "./RecruitmentService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "./RecruitmentService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RecruitmentService.Web.dll"]