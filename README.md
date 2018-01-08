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

* .NET Core 2.0 SDK
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

* Start the Redis service. It can be installed as a service on Windows and `*Nix systems or started manually.

Redis will report that the server is initallised and that it is ready to start accepting connections.

* Start the Command and Query services in your IDE.

The Query service is configured to run on port 4999. 

The Command service runs on port 5000.
