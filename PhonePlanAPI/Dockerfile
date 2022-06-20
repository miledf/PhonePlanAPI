#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PhonePlanAPI/PhonePlanAPI.csproj", "PhonePlanAPI/"]
RUN dotnet restore "PhonePlanAPI/PhonePlanAPI.csproj"
COPY . .
WORKDIR "/src/PhonePlanAPI"
RUN dotnet build "PhonePlanAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhonePlanAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhonePlanAPI.dll"]