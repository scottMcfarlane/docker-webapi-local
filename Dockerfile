FROM microsoft/dotnet:2.0.5-sdk-2.1.4

ENV DOTNET_SKIP_FIRST_TIME_EXPERIENCE true

RUN mkdir -p /app
WORKDIR /app
COPY . /app

ONBUILD COPY ./Data/route-data.json /app/webApi/route-data.json

WORKDIR /app/webApi
RUN dotnet restore

ENTRYPOINT ["dotnet", "run" ]
