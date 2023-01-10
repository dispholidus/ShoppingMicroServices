#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ENV PORT=3000
WORKDIR /app
EXPOSE 3000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingMicroservices.csproj", "."]
RUN dotnet restore "./ShoppingMicroservices.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "ShoppingMicroservices.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingMicroservices.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS="http://*:3000"
ENTRYPOINT ["dotnet", "ShoppingMicroservices.dll"]