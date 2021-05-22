#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5500
ENV ASPNETCORE_URLS=http://*:5500

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HollowMindsDev.BackEnd.API/HollowMindsDev.BackEnd.API.csproj", "HollowMindsDev.BackEnd.API/"]
COPY ["HollowMindsDev.BackEnd.ApplicationCore/HollowMindsDev.BackEnd.ApplicationCore.csproj", "HollowMindsDev.BackEnd.ApplicationCore/"]
COPY ["HollowMindsDev.BackEnd.Infrastructure/HollowMindsDev.BackEnd.Infrastructure.csproj", "HollowMindsDev.BackEnd.Infrastructure/"]
COPY ["HollowMindsDev.BackEnd.Services/HollowMindsDev.BackEnd.Services.csproj", "HollowMindsDev.BackEnd.Services/"]
RUN dotnet restore "HollowMindsDev.BackEnd.API/HollowMindsDev.BackEnd.API.csproj"
COPY . .
WORKDIR "/src/HollowMindsDev.BackEnd.API"
RUN dotnet build "HollowMindsDev.BackEnd.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HollowMindsDev.BackEnd.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HollowMindsDev.BackEnd.API.dll"]