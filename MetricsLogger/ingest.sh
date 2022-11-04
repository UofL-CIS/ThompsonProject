#!/bin/bash

$(while [ 1 ]; do pkill -9 tail && echo Killed tail; sleep 1m; done;) &
$(while [ 1 ]; do ps -aux | rg ' +0:00 tail' && echo HC healthy || echo HC unhealthy; sleep 57; done;) &

echo "Starting tail ingest with key $1 and pattern: $2";

while [ 1 ]; do
    tail -n 0 -f /data/proxydata/logs/*.log | sed 's/==>.*//' | ./root/.dotnet/tools/seqcli ingest -s http://metrics -a $1 --invalid-data=ignore -x "$2";
    echo "Tail ingest restarted!";
done