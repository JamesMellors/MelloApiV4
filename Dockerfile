FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["MelloApiV4/MelloApiV4.csproj", "MelloApiV4_build/"]

RUN dotnet restore "MelloApiV4_build/MelloApiV4.csproj"
COPY . .
WORKDIR "/src/MelloApiV4_build"


RUN ls 
RUN dotnet build "MelloApiV4.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "MelloApiV4.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MelloApiV4.dll"]