# dotnet sample

```
docker compose up
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


# Notes

EventStoreDb Container Images: https://github.com/eventstore/EventStore/pkgs/container/eventstore

