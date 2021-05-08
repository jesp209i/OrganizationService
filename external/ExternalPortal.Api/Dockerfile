#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["external/ExternalPortal.Api/ExternalPortal.Api.csproj", "external/ExternalPortal.Api/"]
COPY ["src/OrganizationService.Shared.Messages/OrganizationService.Shared.Messages.csproj", "src/OrganizationService.Shared.Messages/"]
RUN dotnet restore "external/ExternalPortal.Api/ExternalPortal.Api.csproj"
COPY . .
WORKDIR "/src/external/ExternalPortal.Api"
RUN dotnet build "ExternalPortal.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExternalPortal.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExternalPortal.Api.dll"]