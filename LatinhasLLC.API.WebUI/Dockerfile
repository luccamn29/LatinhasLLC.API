FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["LatinhasLLC.API.WebUI/LatinhasLLC.API.WebUI.csproj", "LatinhasLLC.API.WebUI/"]
COPY ["LatinhasLLC.API.Application/LatinhasLLC.API.Application.csproj", "LatinhasLLC.API.Application/"]
COPY ["LatinhasLLC.API.Domain/LatinhasLLC.API.Domain.csproj", "LatinhasLLC.API.Domain/"]
COPY ["LatinhasLLC.API.Infrastructure/LatinhasLLC.API.Infrastructure.csproj", "LatinhasLLC.API.Infrastructure/"]

RUN dotnet restore "LatinhasLLC.API.WebUI/LatinhasLLC.API.WebUI.csproj"

COPY . .

WORKDIR "/src/LatinhasLLC.API.WebUI"
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "LatinhasLLC.API.WebUI.dll"]
