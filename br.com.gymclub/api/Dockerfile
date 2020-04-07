#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY api/api.csproj api/
COPY viewmodels/viewmodels.csproj viewmodels/
COPY settings/settings.csproj settings/
COPY services/services.csproj services/
COPY domain.models/domain.models.csproj domain.models/
COPY helpers/helpers.csproj helpers/
COPY data.Contexts/data.Contexts.csproj data.Contexts/
COPY EntityConfiguration/EntityConfiguration.csproj EntityConfiguration/
COPY data.repositories/data.repositories.csproj data.repositories/
RUN dotnet restore "api/api.csproj"
COPY . .
WORKDIR "/src/api"
RUN dotnet build "api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]
