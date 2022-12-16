FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["XMASCore.csproj", "XMASCore/"]
RUN dotnet restore "XMASCore/XMASCore.csproj"
COPY . .
WORKDIR "/src/XMASCore"
RUN dotnet build "XMASCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "XMASCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "XMASCore.dll"]
