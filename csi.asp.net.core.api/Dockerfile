#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["csi.asp.net.core.api/csi.asp.net.core.api.csproj", "csi.asp.net.core.api/"]
RUN dotnet restore "csi.asp.net.core.api/csi.asp.net.core.api.csproj"
COPY . .
WORKDIR "/src/csi.asp.net.core.api"
RUN dotnet build "csi.asp.net.core.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "csi.asp.net.core.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "csi.asp.net.core.api.dll"]