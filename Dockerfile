FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY  /DesafioStefanini.sln ./
COPY  ./DesafioStefanini.Domain/*.csproj ./DesafioStefanini.Domain/
COPY  ./DesafioStefanini.Data/*.csproj ./DesafioStefanini.Data/
COPY  ./DesafioStefanini.IoC/*.csproj ./DesafioStefanini.IoC/
COPY  ./DesafioStefanini.Api/*.csproj ./DesafioStefanini.Api/



RUN dotnet restore
COPY . .
WORKDIR /src/DesafioStefanini.Domain
RUN dotnet build -c Release -o /app

WORKDIR /src/DesafioStefanini.Data
RUN dotnet build -c Release -o /app

WORKDIR /src/DesafioStefanini.IoC
RUN dotnet build -c Release -o /app

WORKDIR /src/DesafioStefanini.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DesafioStefanini.Api.dll"]




