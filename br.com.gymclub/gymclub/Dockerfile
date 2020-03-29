FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY gymclub/gymclub.api.csproj gymclub/
RUN dotnet restore "gymclub/gymclub.api.csproj"
COPY . .
WORKDIR "/src/gymclub"
RUN dotnet build "gymclub.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gymclub.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gymclub.api.dll"]
