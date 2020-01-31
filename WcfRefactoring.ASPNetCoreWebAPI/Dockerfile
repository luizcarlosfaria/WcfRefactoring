#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["WcfRefactoring.ASPNetCoreWebAPI/WcfRefactoring.ASPNetCoreWebAPI.csproj", "WcfRefactoring.ASPNetCoreWebAPI/"]
RUN dotnet restore "WcfRefactoring.ASPNetCoreWebAPI/WcfRefactoring.ASPNetCoreWebAPI.csproj"
COPY . .
WORKDIR "/src/WcfRefactoring.ASPNetCoreWebAPI"
RUN dotnet build "WcfRefactoring.ASPNetCoreWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WcfRefactoring.ASPNetCoreWebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WcfRefactoring.ASPNetCoreWebAPI.dll"]