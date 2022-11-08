#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dotnetmovieportal/dotnetmovieportal.csproj", "dotnetmovieportal/"]
RUN dotnet restore "dotnetmovieportal/dotnetmovieportal.csproj"
COPY . .
WORKDIR "/src/dotnetmovieportal"
RUN dotnet build "dotnetmovieportal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnetmovieportal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnetmovieportal.dll"]
