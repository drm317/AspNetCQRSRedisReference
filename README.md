# CQRS and Event Sourcing with ASP.Net Core 2.0 and Redis

This is a simple CQRS and Event Sourcing application using ASP.Net Core 2.0, CQRSlite and Redis. The following design patterns are used:

* Command Query Responsibility Separation (CQRS).
* Event Sourcing

The following technologies are used

* ASP.Net Core 2.0
* CQRSlite
* Redis

## Prerequisites

The system consists of two Web API applications and an underlying Redis cache. The following software is required to build and run the code

* .NET Core 3.1 SDK
* Redis 4.0.6

## Running this Example

### 1. Build the Code

Clone the Git repository to a directory

```bash
git clone https://github.com/drm317/asp-net-cqrs-redis-reference.git
```

Then build the code within your IDE.

### 2. Start the Services

There are three services in this example

* Redis - Used for the read model data store
* Command - CQRS command service used to create orders
* Query - CQRS query service used to query orders

The CQRSlite framework is used to provide a basic CQRS infrastructure. Order creation events are written to an in-memory event store by the command service. An event handler publishes these events and an entry is cached in the Redis read data store for the query service.

* Start the Redis service. It can be installed as a service on Windows and Nix systems or started manually from the command line.

```$ redis-server```

* Start the Command service

```
AspNetCoreCqrsRedis.API.Command

$ dotnet run
```

and the Query service

```
AspNetCoreCqrsRedis.API.Query

$ dotnet run
```

### 3. Run the Tests

The AspNetCoreCqrsRedis.Test test project includes unit and integration tests. 

* Unit Tests - The WhenOrderCreated.cs unit test uses fake implementations of the key CQRSlite framework classes. It covers the order creation scenario and verifies that an OrderCreatedEvent is correctly handled.

* Integration Tests - The EndToEndTest.cs integration test creates an order via the Command service. The event store is updated and an event is published to the query read data store. The Query service returns the cached order from the read data store.

```
AspNetCoreCqrsRedis.Test

$ dotnet test
```

