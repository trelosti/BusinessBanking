#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

RUN apt-get update && apt-get install -y locales

# Locale
RUN sed -i -e \
  's/# ru_RU.UTF-8 UTF-8/ru_RU.UTF-8 UTF-8/' /etc/locale.gen \
   && locale-gen

ENV LANG ru_RU.UTF-8
ENV LANGUAGE ru_RU:ru
ENV LC_LANG ru_RU.UTF-8
ENV LC_ALL ru_RU.UTF-8

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BusinessBanking/BusinessBanking.csproj", "BusinessBanking/"]
COPY ["BusinessBanking.DAL/BusinessBanking.DAL.csproj", "BusinessBanking.DAL/"]
COPY ["BusinessBanking.Domain/BusinessBanking.Domain.csproj", "BusinessBanking.Domain/"]
COPY ["BusinessBanking.Interface/BusinessBanking.Interface.csproj", "BusinessBanking.Interface/"]
COPY ["BusinessBanking.Repository/BusinessBanking.Repository.csproj", "BusinessBanking.Repository/"]
RUN dotnet restore "BusinessBanking/BusinessBanking.csproj"
COPY . .
WORKDIR "/src/BusinessBanking"
RUN dotnet build "BusinessBanking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BusinessBanking.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BusinessBanking.dll"]