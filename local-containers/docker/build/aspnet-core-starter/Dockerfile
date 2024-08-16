ARG BASE_IMAGE
ARG BUILD_CONFIGURATION

FROM ${BASE_IMAGE}

# Copy in the headapps code
COPY ./headapps ./app/
COPY ./local-containers/docker/build/aspnet-core-starter/nuget.config ./app/aspnet-core-starter

WORKDIR /app/aspnet-core-starter

RUN dotnet restore aspnet-core-starter.csproj
RUN dotnet build aspnet-core-starter.csproj -c $BUILD_CONFIGURATION

EXPOSE 5000
ENTRYPOINT ["dotnet", "run"]