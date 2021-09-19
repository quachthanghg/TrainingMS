FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Identity.STS.Identity/Identity.STS.Identity.csproj", "src/Identity.STS.Identity/"]
COPY ["src/Identity.Shared.Configuration/Identity.Shared.Configuration.csproj", "src/Identity.Shared.Configuration/"]
COPY ["src/Identity.EntityFramework.Shared/Identity.EntityFramework.Shared.csproj", "src/Identity.EntityFramework.Shared/"]
COPY ["src/Identity.EntityFramework.Identity/Identity.EntityFramework.Identity.csproj", "src/Identity.EntityFramework.Identity/"]
COPY ["src/Identity.EntityFramework/Identity.EntityFramework.csproj", "src/Identity.EntityFramework/"]
COPY ["src/Identity.EntityFramework.Extensions/Identity.EntityFramework.Extensions.csproj", "src/Identity.EntityFramework.Extensions/"]
COPY ["src/Identity.EntityFramework.Configuration/Identity.EntityFramework.Configuration.csproj", "src/Identity.EntityFramework.Configuration/"]
COPY ["src/Identity.Shared/Identity.Shared.csproj", "src/Identity.Shared/"]
COPY ["src/Identity.BusinessLogic.Identity/Identity.BusinessLogic.Identity.csproj", "src/Identity.BusinessLogic.Identity/"]
COPY ["src/Identity.BusinessLogic.Shared/Identity.BusinessLogic.Shared.csproj", "src/Identity.BusinessLogic.Shared/"]
RUN dotnet restore "src/Identity.STS.Identity/Identity.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/Identity.STS.Identity"
RUN dotnet build "Identity.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Identity.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "Identity.STS.Identity.dll"]