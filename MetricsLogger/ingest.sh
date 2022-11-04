#!/bin/bash

PATTERN="[{@t:*}] - {UpstreamStatus:nat} {StatusCode:nat} - {HttpProtocol:*} {HttpScheme:*} {Host:*} \"{RequestUri:*}\" [Client {RemoteAddress:*}] [Length {BodyLength:nat}] [{GzipRatio:*}] [Sent-to {SentToServer:*}] \"{UserAgent:*}\" \"{Referrer:*}\"";

$(while [ 1 ]; do pkill -9 tail && echo Killed tail; sleep 1m; done;) &
$(while [ 1 ]; do ps -aux | rg ' +0:00 tail' && echo HC healthy || echo HC unhealthy; sleep 57; done;) &

echo "Starting tail ingest with key $1 and pattern: $PATTERN";

while [ 1 ]; do
    tail -n 0 -f /data/proxydata/logs/*.log | sed 's/==>.*//' | ./root/.dotnet/tools/seqcli ingest -s http://metrics -a $1 --invalid-data=ignore -x "$PATTERN";
    echo "Tail ingest restarted!";
done