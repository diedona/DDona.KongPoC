#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DDona.KongPoC.ProductsAPI/DDona.KongPoC.ProductsAPI.csproj", "DDona.KongPoC.ProductsAPI/"]
RUN dotnet restore "DDona.KongPoC.ProductsAPI/DDona.KongPoC.ProductsAPI.csproj"
COPY . .
WORKDIR "/src/DDona.KongPoC.ProductsAPI"
RUN dotnet build "DDona.KongPoC.ProductsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DDona.KongPoC.ProductsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DDona.KongPoC.ProductsAPI.dll"]