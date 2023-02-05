#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HelloDocker.Console/HelloDocker.Console.csproj", "HelloDocker.Console/"]
RUN dotnet restore "HelloDocker.Console/HelloDocker.Console.csproj"
COPY . .
WORKDIR "/src/HelloDocker.Console"
RUN dotnet build "HelloDocker.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HelloDocker.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloDocker.Console.dll"]