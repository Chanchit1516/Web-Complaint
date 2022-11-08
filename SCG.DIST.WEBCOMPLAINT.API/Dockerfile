#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SCG.DIST.WEBCOMPLAINT.API/SCG.DIST.WEBCOMPLAINT.API.csproj", "SCG.DIST.WEBCOMPLAINT.API/"]
RUN dotnet restore "SCG.DIST.WEBCOMPLAINT.API/SCG.DIST.WEBCOMPLAINT.API.csproj"
COPY . .
WORKDIR "/src/SCG.DIST.WEBCOMPLAINT.API"
RUN dotnet build "SCG.DIST.WEBCOMPLAINT.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SCG.DIST.WEBCOMPLAINT.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SCG.DIST.WEBCOMPLAINT.API.dll"]