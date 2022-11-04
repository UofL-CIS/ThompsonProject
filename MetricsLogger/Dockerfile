FROM ubuntu:latest

RUN apt update
RUN apt install dotnet6 curl ripgrep -y
RUN dotnet tool install --global seqcli

ARG API_KEY_ARG
ARG EXT_PATTERN_ARG

ENV API_KEY=$API_KEY_ARG
ENV EXT_PATTERN=$EXT_PATTERN_ARG

COPY . .

CMD ./ingest.sh $API_KEY $EXT_PATTERN