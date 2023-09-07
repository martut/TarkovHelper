FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TarkovHelper.API/TarkovHelper.API.csproj", "TarkovHelper.API/"]
RUN dotnet restore "TarkovHelper.API/TarkovHelper.API.csproj"
COPY . .
WORKDIR "/src/TarkovHelper.API"
RUN dotnet build "TarkovHelper.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TarkovHelper.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TarkovHelper.API.dll"]
