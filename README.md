# dotnet sample

```
https://docs.dapr.io/operations/hosting/self-hosted/self-hosted-airgap/

docker compose up

C:\dapr\dapr.exe init --slim

cd ~/.dapr/bin
# start dapr placement
cd ~/.dapr/bin ; .\placement.exe --metrics-port 9091 -port 6050

# dapr dashboard
cd ~/.dapr/bin ; .\dashboard.exe -port 8088

# start dapr runtime
C:\dapr\dapr.exe run --app-id esdemo --config (Join-Path -Path (Get-Location)  ".dapr" "config.yaml")


# run payment sidecar
C:\dapr\dapr.exe run --app-id esdemo-bookings-payment --app-port 5052 --dapr-http-port 3552 --dapr-grpc-port 60052 --config (Join-Path -Path (Get-Location) ".dapr" "config.yaml") --components-path (Join-Path -Path (Get-Location)  ".dapr" "components")



```
## URLS

| Service                     | URL                           | notes            |
|-----------------------------|-------------------------------|------------------|
| Booking API Swagger         | http://localhost:5051/swagger | admin / admin    |
| Booking Payment API Swagger | http://localhost:5052/swagger | admin / admin    |
| Grafana                     | http://localhost:3000         | admin / admin    |
| EventStoreDb                | http://localhost:2113         | admin / changeit |
| Prometeus                   | http://localhost:9090         |  |
| Seq                         | http://localhost:5341         |  |
| Zipkin                      | http://localhost:9411         |  |
| MongoDb                     | localhost:27017               |  |
| Redis                       | localhost:6379                |  |


# Notes

EventStoreDb Container Images: https://github.com/eventstore/EventStore/pkgs/container/eventstore

