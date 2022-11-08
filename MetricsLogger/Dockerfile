FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN dotnet tool install --global seqcli

FROM ubuntu:latest

RUN apt update
RUN apt install -y ripgrep

ARG API_KEY_ARG

ENV API_KEY=$API_KEY_ARG

COPY ingest.sh .

CMD ./ingest.sh $API_KEY