#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["properties2csharp-website/properties2csharp-website.csproj", "properties2csharp-website/"]
COPY ["properties2csharp/properties2csharp.csproj", "properties2csharp/"]
RUN dotnet restore "properties2csharp-website/properties2csharp-website.csproj"
COPY . .
WORKDIR "/src/properties2csharp-website"
RUN dotnet build "properties2csharp-website.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "properties2csharp-website.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "properties2csharp-website.dll"]