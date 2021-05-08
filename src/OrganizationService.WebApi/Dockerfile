#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["/src/OrganizationService.WebApi/OrganizationService.WebApi.csproj", "src/OrganizationService.WebApi/"]
COPY ["/src/OrganizationService.ApplicationService/OrganizationService.ApplicationService.csproj", "src/OrganizationService.ApplicationService/"]
COPY ["/src/OrganizationService.Infrastructure/OrganizationService.Infrastructure.csproj", "src/OrganizationService.Infrastructure/"]
COPY ["/src/OrganizationService.Domain/OrganizationService.Domain.csproj", "src/OrganizationService.Domain/"]
COPY ["/src/OrganizationService.Persistence/OrganizationService.Persistence.csproj", "src/OrganizationService.Persistence/"]
RUN dotnet restore "src/OrganizationService.WebApi/OrganizationService.WebApi.csproj"
COPY . .
WORKDIR "/src/src/OrganizationService.WebApi"
RUN dotnet build "OrganizationService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrganizationService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrganizationService.WebApi.dll"]