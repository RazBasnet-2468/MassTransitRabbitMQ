
using MassTransit;
using SharedModels;
using System.Text.Json;

namespace ConsumerService
{
    public class UserCreatedConsumer : IConsumer<IUserCreated>
    {
        public async Task Consume(ConsumeContext<IUserCreated> context)
        {
            var jsonMessage = JsonSerializer.Serialize(context.Message);
            Console.WriteLine(jsonMessage);
            await Task.CompletedTask;
        }
    }
}
