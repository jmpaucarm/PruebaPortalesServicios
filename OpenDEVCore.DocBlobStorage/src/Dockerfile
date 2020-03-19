FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY ./Assemblies/ ./
COPY OpenDEVCore.DocBlobStorage/src/*.csproj ./
RUN dotnet restore
COPY OpenDEVCore.DocBlobStorage/src/ ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
ENV TZ=America/Guayaquil
ARG environment=Development
ENV ASPNETCORE_ENVIRONMENT=$environment
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

COPY OpenDEVCore.DocBlobStorage/src/portales_root.crt /usr/local/share/ca-certificates/
RUN update-ca-certificates

WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "OpenDEVCore.DocBlobStorage.dll"]
