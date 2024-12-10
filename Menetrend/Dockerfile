# .NET SDK kép az építéshez (7.0)
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Másold be a projektfájlokat
COPY *.csproj ./
RUN dotnet restore

# Teljes projekt másolása és build
COPY . ./
RUN dotnet publish -c Release -o out

# .NET Runtime futókörnyezet (7.0)
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Menetrend.dll"]
