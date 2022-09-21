#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ThompsonProject.WebApi/ThompsonProject.WebApi.csproj", "ThompsonProject.WebApi/"]
RUN dotnet restore "ThompsonProject.WebApi/ThompsonProject.WebApi.csproj"
COPY . .
WORKDIR "/src/ThompsonProject.WebApi"
RUN dotnet build "ThompsonProject.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ThompsonProject.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK --interval=5s --timeout=30s --retries=4 CMD curl --fail http://localhost:80/hc || exit 1
ENTRYPOINT ["dotnet", "ThompsonProject.WebApi.dll"]