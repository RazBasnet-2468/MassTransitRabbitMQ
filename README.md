# MassTransit and RabbitMQ Integration in .NET 8

This project demonstrates how to implement messaging in a .NET 8 application using both **MassTransit** and **RabbitMQ.Client**. It showcases two different approaches for producing and consuming messages via RabbitMQ:

### MassTransit
MassTransit is a powerful and flexible library that simplifies the process of message-based communication in distributed systems. It provides a high-level API for message publishing and consumption, allowing developers to focus on business logic rather than infrastructure.

### RabbitMQ.Client
RabbitMQ.Client is a low-level library that directly interacts with RabbitMQ. While it offers more control and customization for message handling, it requires more boilerplate code compared to MassTransit.

## Solution Structure
The solution consists of two main components:

- **Producer API**: A web API application that sends messages.
- **Consumer Console App**: A console application that listens for messages.

This setup provides a practical example of how to integrate RabbitMQ with .NET 8 applications for building robust and scalable microservices or event-driven architectures.

## Key Features

- **MassTransit Integration**: High-level messaging capabilities.
- **RabbitMQ.Client Integration**: Low-level messaging for fine-grained control.
- **In-Memory Database**: Demonstration using Entity Framework Core.
- **Swagger Integration**: Easy API documentation and testing.

## Getting Started

1. Clone the repository.
2. Install the necessary dependencies.
3. Configure RabbitMQ and the required services.
4. Run the Producer API and Consumer Console App to see messaging in action.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [RabbitMQ](https://www.rabbitmq.com/download.html)

## Installation and Setup

1. Install RabbitMQ and ensure it is running.
2. Configure `appsettings.json` for connection strings and RabbitMQ settings.
3. Run the Producer API and test endpoints using Swagger.
4. Run the Consumer Console App to listen to messages.

## Contributing

Feel free to open issues and submit pull requests to improve the project.

## License

This project is licensed under the MIT License.
