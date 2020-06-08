FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["DCG.Equipment.WebAPI/DCG.Equipment.WebAPI.csproj", "DCG.Equipment.WebAPI/"]

RUN dotnet restore "DCG.Equipment.WebAPI/DCG.Equipment.WebAPI.csproj"
COPY . .
WORKDIR "/src/DCG.Equipment.WebAPI"
RUN dotnet build "DCG.Equipment.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCG.Equipment.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCG.Equipment.WebAPI.dll"]