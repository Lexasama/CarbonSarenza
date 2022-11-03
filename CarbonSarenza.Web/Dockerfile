#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarbonSarenza.Web/CarbonSarenza.Web.csproj", "CarbonSarenza.Web/"]
RUN dotnet restore "CarbonSarenza.Web/CarbonSarenza.Web.csproj"
COPY . .
WORKDIR "/src/CarbonSarenza.Web"
RUN dotnet build "CarbonSarenza.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarbonSarenza.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarbonSarenza.Web.dll"]