FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS=http://*:80
#ENV ASPNETCORE_ENVIRONMENT=”production”

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MelloApiV4/MelloApiV4.csproj", "MelloApiV4/"]
RUN dotnet restore "MelloApiV4/MelloApiV4.csproj"
COPY . .
WORKDIR "/src/MelloApiV4"

RUN dotnet build "MelloApiV4.csproj" -c Release -o /app/build 
 #-runtime linux-x64
#--no-restore


FROM build AS publish
RUN dotnet publish "MelloApiV4.csproj" -c Release -o /app/publish 


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MelloApiV4.dll"]