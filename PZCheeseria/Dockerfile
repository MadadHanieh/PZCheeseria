FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PZCheeseria.csproj", "."]
RUN dotnet restore "./PZCheeseria.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PZCheeseria.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PZCheeseria.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PZCheeseria.dll"]