using Producer.RabbitMQ.Connection;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Producer.RabbitMQ
{
    public class RabbitMqProducer : IMessageProducer
    {
        private readonly IRabbitMqConnection _connection;

        // Constructor should accept IRabbitMqConnection if that's what is registered in DI
        public RabbitMqProducer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public void SendMessage<T>(T message)
        {
            using var channel = _connection.Connection.CreateModel();
            channel.QueueDeclare("user-created-event-rabbit", exclusive: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "user-created-event-rabbit", body: body);
        }
    }
}
