# Hackamole.Quietu

### Install Kafka

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

