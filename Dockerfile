FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MelloApiV4/MelloApiV4.csproj", "MelloApiV4/"]

RUN dotnet restore "MelloApiV4/MelloApiV4.csproj"
WORKDIR "/src/MelloApiV4"
COPY . .

RUN dotnet build "MelloApiV4.csproj" -c Release -r linux-musl-x64  -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "MelloApiV4.csproj" -c Release -r linux-musl-x64 -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MelloApiV4.dll"]