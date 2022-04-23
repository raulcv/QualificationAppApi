#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["QualificationApp.Api/QualificationApp.Api.csproj", "QualificationApp.Api/"]
COPY ["QualificationApp.Infrastructure/QualificationApp.Infrastructure.csproj", "QualificationApp.Infrastructure/"]
COPY ["QualificationApp.Domain/QualificationApp.Domain.csproj", "QualificationApp.Domain/"]
COPY ["QualificationApp.Utilities/QualificationApp.Utilities.csproj", "QualificationApp.Utilities/"]
RUN dotnet restore "QualificationApp.Api/QualificationApp.Api.csproj"
COPY . .
WORKDIR "/src/QualificationApp.Api"
RUN dotnet build "QualificationApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QualificationApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QualificationApp.Api.dll"]