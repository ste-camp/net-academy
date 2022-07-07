FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NetAcademy.Domain/NetAcademy.Domain.csproj", "NetAcademy.Domain/"]
COPY ["NetAcademy.Repositories/NetAcademy.Repositories.csproj", "NetAcademy.Repositories/"]
COPY ["NetAcademy.Services/NetAcademy.Services.csproj", "NetAcademy.Services/"]
COPY ["NetAcademy.Web/NetAcademy.Web.csproj", "NetAcademy.Web/"]
RUN dotnet restore "NetAcademy.Web/NetAcademy.Web.csproj"
COPY . .
WORKDIR "/src/NetAcademy.Web"
RUN dotnet build "NetAcademy.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetAcademy.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetAcademy.Web.dll"]
