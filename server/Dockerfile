FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Thunders.Api/Thunders.Api.csproj", "Thunders.Api/"]
COPY ["Thunders.Domain/Thunders.Domain.csproj", "Thunders.Domain/"]
COPY ["Thunders.Infra/Thunders.Infra.csproj", "Thunders.Infra/"]
COPY ["Thunders.Service/Thunders.Service.csproj", "Thunders.Service/"]
RUN dotnet restore "Thunders.Api/Thunders.Api.csproj"
COPY . .
WORKDIR "/src/Thunders.Api"
RUN dotnet build "Thunders.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Thunders.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Thunders.Api.dll"]