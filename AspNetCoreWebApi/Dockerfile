## See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

## Also reference for understanding of MSBuild properties for Docker:
##  https://docs.microsoft.com/en-us/visualstudio/containers/container-msbuild-properties?view=vs-2022

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AspNetCoreWebApi/AspNetCoreWebApi.csproj", "AspNetCoreWebApi/"]
RUN dotnet restore "AspNetCoreWebApi/AspNetCoreWebApi.csproj"
COPY . .
WORKDIR "/src/AspNetCoreWebApi"
RUN dotnet build "AspNetCoreWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AspNetCoreWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspNetCoreWebApi.dll"]
