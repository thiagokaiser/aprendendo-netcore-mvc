#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/aspnetcore:2.0-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["SiteWeb/SiteWeb.csproj", "SiteWeb/"]
RUN dotnet restore "SiteWeb/SiteWeb.csproj"
COPY . .
WORKDIR "/src/SiteWeb"
RUN dotnet build "SiteWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SiteWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SiteWeb.dll"]