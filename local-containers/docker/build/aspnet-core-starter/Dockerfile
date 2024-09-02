ARG BASE_IMAGE
FROM ${BASE_IMAGE}
ARG PROJECT_FILE
WORKDIR /app

COPY ${PROJECT_FILE} .
COPY ./headapps/Directory.Packages.props .
COPY ./nuget.config .
RUN dotnet restore

COPY ./headapps/aspnet-core-starter ./
#RUN if not exist "obj" mkdir "obj"
#RUN if not exist "bin" mkdir "bin"

CMD ["dotnet", "watch", "run", -v, "--urls", "http://*:80"]