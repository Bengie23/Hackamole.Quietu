# Hackamole.Quietu

### Install Kafka and create a network

### pull images
```
docker pull confluentinc/cp-zookeeper
docker pull confluentinc/cp-kafka
```

### create network
```
docker network create kafka
```

### create containers with the new network
```
docker run -d --network=kafka --name=zookeeper -e ZOOKEEPER_CLIENT_PORT=2181 -e ZOOKEEPER_TICK_TIME=2000 -p 2181:2181 confluentinc/cp-zookeeper
docker run -d --network=kafka --name=kafka -p 9092:9092 -e KAFKA_ZOOKEEPER_CONNECT=zookeeper:2181 -e KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://localhost:9092 confluentinc/cp-kafka
```
