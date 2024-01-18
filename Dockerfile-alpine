#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0.418-alpine3.19-amd64 AS build
WORKDIR /src
COPY ["Poc.Foxit.Api.csproj", "."]

RUN dotnet restore "./Poc.Foxit.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Poc.Foxit.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Poc.Foxit.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0.26-alpine3.19-amd64 AS base

WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
RUN addgroup nonroot && adduser -S -G nonroot nonroot
USER nonroot
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Poc.Foxit.Api.dll"]


FROM base AS final