#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/ContactKeeper.Api/ContactKeeper.Api.csproj", "src/Apps/ContactKeeper.Api/"]
COPY ["src/Common/ContactKeeper.Infrastructure/ContactKeeper.Infrastructure.csproj", "src/Common/ContactKeeper.Api.Infrastructure/"]
COPY ["src/Common/ContactKeeper.Application/ContactKeeper.Application.csproj", "src/Common/ContactKeeper.Api.Application/"]
COPY ["src/Common/ContactKeeper.Domain/ContactKeeper.Domain.csproj", "src/Common/ContactKeeper.Api.Domain/"]
RUN dotnet restore "src/Apps/ContactKeeper.Api/ContactKeeper.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/ContactKeeper.Api"
RUN dotnet build "ContactKeeper.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactKeeper.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactKeeper.Api.dll"]