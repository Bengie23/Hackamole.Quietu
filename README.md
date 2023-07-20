# Hackamole.Quietu

## Installation

### Install .NET Core
```
https://dotnet.microsoft.com/en-us/download/dotnet/7.0
```

### Single instance of kafka and zookeeper (perfect for a fast demo)
```
cd hackamole.quietu.docker
docker compose -f zk-single-kafka-single.yml up
```

### Kafka, Zookeeper, admin UI and more (perfect to play around and get to know the ecosystem)
```
cd hackamole.quietu.docker
docker compose -f full-stack.yml up
```
user: ```admin@admin.io``` password: ```admin```


## How to grow horizontally with more event handlers

In an event-driven application, messages(events) and message brokers are essential to decouple asynchronous operations in our domain. Our application has one event ```authorizedEvent``` with multiple handlers (```PrincipalAttempedProductEventHandler``` and ```ProductCodeUsageEventHandler``` performing different actions in parallel. This is how we can represent in a diagram the communication that happens after raising that event from the command.

![AuthorizedEvent_2x](https://github.com/Bengie23/Hackamole.Quietu/assets/9501182/617b2269-974e-43ea-8cc9-c90aec7e15c0)

The gray areas are not part of the current solution, but they illustrate how easy it could be to create Event Handlers that extend the functionality of the microservice without affecting the core API that handles authorization for a product code and all of them are working asynchronously. _**possibilities are endless.**_
