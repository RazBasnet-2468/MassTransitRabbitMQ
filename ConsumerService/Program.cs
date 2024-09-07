using ConsumerService;
using MassTransit;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// NOTE: Run only one section at a time. Comment out other section before running.


// consume using MassTransit

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("user-created-event-mass", e =>
    {
        e.Consumer<UserCreatedConsumer>();
    });
});
await busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}



// consume using RabbitMQclient

//var factory = new ConnectionFactory
//{
//    HostName = "localhost",
//};

//var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();
//channel.QueueDeclare("user-created-event-rabbit", exclusive: false);

//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (sender, args) =>
//{
//    var body = args.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    Console.WriteLine($"Message received:{message}");
//};
//channel.BasicConsume(queue: "user-created-event-rabbit", autoAck: true, consumer: consumer);

//Console.ReadLine();