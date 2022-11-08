FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
RUN dotnet tool install --global seqcli

FROM mcr.microsoft.com/dotnet/runtime:6.0.10-jammy
RUN apt update && apt install -y ripgrep

COPY --from=base /root/.dotnet/tools /root/.dotnet/tools

ARG API_KEY_ARG
ENV API_KEY=$API_KEY_ARG

COPY ingest.sh .
CMD ./ingest.sh $API_KEY