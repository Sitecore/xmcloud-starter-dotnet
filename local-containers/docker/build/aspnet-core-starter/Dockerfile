ARG BASE_IMAGE
FROM ${BASE_IMAGE}
ARG PROJECT_FILE
WORKDIR /app

COPY ${PROJECT_FILE} .
COPY ./headapps/Directory.Packages.props ./../
COPY ./nuget.config ./../

COPY ./headapps/aspnet-core-starter ./

CMD ["dotnet", "watch", "run", -v, "--urls", "http://*:80"]