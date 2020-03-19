FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app
COPY ./Assemblies/ ./
COPY OpenDEVCore.Configuration/src/*.csproj ./
RUN dotnet restore
COPY OpenDEVCore.Configuration/src/ ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime
ENV TZ=America/Guayaquil
ARG environment=Development
ENV ASPNETCORE_ENVIRONMENT=$environment
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "OpenDEVCore.Configuration.dll"]