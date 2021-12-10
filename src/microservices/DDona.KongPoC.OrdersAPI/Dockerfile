#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/microservices/DDona.KongPoC.OrdersAPI/DDona.KongPoC.OrdersAPI.csproj", "src/microservices/DDona.KongPoC.OrdersAPI/"]
RUN dotnet restore "src/microservices/DDona.KongPoC.OrdersAPI/DDona.KongPoC.OrdersAPI.csproj"
COPY . .
WORKDIR "/src/src/microservices/DDona.KongPoC.OrdersAPI"
RUN dotnet build "DDona.KongPoC.OrdersAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DDona.KongPoC.OrdersAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDona.KongPoC.OrdersAPI.dll"]
