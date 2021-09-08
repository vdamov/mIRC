#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5434
RUN curl -sL https://deb.nodesource.com/setup_lts.x |  bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN curl -sL https://deb.nodesource.com/setup_lts.x |  bash -
RUN apt-get install -y nodejs
WORKDIR /src
COPY ["mIRC.Web/mIRC.Web.csproj", "mIRC.Web/"]
COPY ["mIRC.Db/mIRC.Db.csproj", "mIRC.Db/"]
COPY ["mIRC.Core/mIRC.Core.csproj", "mIRC.Core/"]
RUN dotnet restore "mIRC.Web/mIRC.Web.csproj"
COPY . .
WORKDIR "/src/mIRC.Web"
RUN dotnet build "mIRC.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mIRC.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mIRC.Web.dll"]