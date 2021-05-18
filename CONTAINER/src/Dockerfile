#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HollowMindsDev.BackEnd.WebApp/HollowMindsDev.BackEnd.WebApp.csproj", "HollowMindsDev.BackEnd.WebApp/"]
COPY ["HollowMindsDev.BackEnd.ApplicationCore/HollowMindsDev.BackEnd.ApplicationCore.csproj", "HollowMindsDev.BackEnd.ApplicationCore/"]
COPY ["HollowMindsDev.BackEnd.Infrastructure/HollowMindsDev.BackEnd.Infrastructure.csproj", "HollowMindsDev.BackEnd.Infrastructure/"]
COPY ["HollowMindsDev.BackEnd.Services/HollowMindsDev.BackEnd.Services.csproj", "HollowMindsDev.BackEnd.Services/"]
RUN dotnet restore "HollowMindsDev.BackEnd.WebApp/HollowMindsDev.BackEnd.WebApp.csproj"
COPY . .
WORKDIR "/src/HollowMindsDev.BackEnd.WebApp"
RUN dotnet build "HollowMindsDev.BackEnd.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HollowMindsDev.BackEnd.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HollowMindsDev.BackEnd.WebApp.dll"]