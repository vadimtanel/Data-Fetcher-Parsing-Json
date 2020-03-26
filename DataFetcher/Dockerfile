FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DataFetcher/DataFetcher.csproj", "DataFetcher/"]
RUN dotnet restore "DataFetcher/DataFetcher.csproj"
COPY . .
WORKDIR "/src/DataFetcher"
RUN dotnet build "DataFetcher.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataFetcher.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataFetcher.dll"]