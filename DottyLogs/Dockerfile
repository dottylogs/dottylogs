#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DottyLogs/DottyLogs.csproj", "DottyLogs/"]
COPY ["DottyLogs.Server.Sqlite/DottyLogs.Server.Sqlite.csproj", "DottyLogs.Server.Sqlite/"]
COPY ["DottyLogs.Server.DbModels/DottyLogs.Server.DbModels.csproj", "DottyLogs.Server.DbModels/"]
COPY ["DottyLogs.Server/DottyLogs.Server.csproj", "DottyLogs.Server/"]
COPY ["DottyLogs.Models/DottyLogs.Models.csproj", "DottyLogs.Models/"]
COPY ["DottyLogs.Ui/DottyLogs.Ui.csproj", "DottyLogs.Ui/"]
RUN dotnet restore "DottyLogs/DottyLogs.csproj"
COPY . .
WORKDIR "/src/DottyLogs"
RUN dotnet build "DottyLogs.csproj" -c Release -o /app/build

FROM node:12 as buildjs
WORKDIR /srcjs
COPY ["DottyLogs.Ui/client-app/package*.json", "./"]
RUN npm i
COPY ["DottyLogs.Ui/client-app/", "./"]
RUN npm run build

FROM build AS publish
RUN dotnet publish "DottyLogs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=buildjs /srcjs/dist ./dist/
ENTRYPOINT ["dotnet", "DottyLogs.dll"]