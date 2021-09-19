FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Identity/Identity.csproj", "src/Identity/"]
COPY ["src/Identity.EntityFramework.MySql/Identity.EntityFramework.MySql.csproj", "src/Identity.EntityFramework.MySql/"]
COPY ["src/Identity.EntityFramework.Identity/Identity.EntityFramework.Identity.csproj", "src/Identity.EntityFramework.Identity/"]
COPY ["src/Identity.EntityFramework/Identity.EntityFramework.csproj", "src/Identity.EntityFramework/"]
COPY ["src/Identity.EntityFramework.Extensions/Identity.EntityFramework.Extensions.csproj", "src/Identity.EntityFramework.Extensions/"]
COPY ["src/Identity.EntityFramework.Shared/Identity.EntityFramework.Shared.csproj", "src/Identity.EntityFramework.Shared/"]
COPY ["src/Identity.EntityFramework.Configuration/Identity.EntityFramework.Configuration.csproj", "src/Identity.EntityFramework.Configuration/"]
COPY ["src/Identity.BusinessLogic/Identity.BusinessLogic.csproj", "src/Identity.BusinessLogic/"]
COPY ["src/Identity.BusinessLogic.Shared/Identity.BusinessLogic.Shared.csproj", "src/Identity.BusinessLogic.Shared/"]
COPY ["src/Identity.EntityFramework.PostgreSQL/Identity.EntityFramework.PostgreSQL.csproj", "src/Identity.EntityFramework.PostgreSQL/"]
COPY ["src/Identity.BusinessLogic.Identity/Identity.BusinessLogic.Identity.csproj", "src/Identity.BusinessLogic.Identity/"]
COPY ["src/Identity.UI/Identity.UI.csproj", "src/Identity.UI/"]
COPY ["src/Identity.Shared.Configuration/Identity.Shared.Configuration.csproj", "src/Identity.Shared.Configuration/"]
COPY ["src/Identity.Shared/Identity.Shared.csproj", "src/Identity.Shared/"]
COPY ["src/Identity.EntityFramework.SqlServer/Identity.EntityFramework.SqlServer.csproj", "src/Identity.EntityFramework.SqlServer/"]
RUN dotnet restore "src/Identity/Identity.csproj"
COPY . .
WORKDIR "/src/src/Identity"
RUN dotnet build "Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Identity.dll"]