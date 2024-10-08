#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/services/Restaurant/Restaurant.API/Restaurant.API.csproj", "src/services/Restaurant/Restaurant.API/"]
RUN dotnet restore "src/services/Restaurant/Restaurant.API/Restaurant.API.csproj"
COPY . .
WORKDIR "/src/src/services/Restaurant/Restaurant.API"
RUN dotnet build "Restaurant.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.API.dll"]