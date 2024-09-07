using MassTransit;
using Producer.Data;
using Producer.DTO;
using Producer.RabbitMQ;
using SharedModels;

namespace Producer.Service
{
    public class UserService : IUserServiceMassTransit, IUserServiceRabbitMqClient
    {
        private readonly UserDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMessageProducer _messageProducer;
        public UserService(UserDbContext context, IPublishEndpoint publishEndpoint, IMessageProducer messageProducer)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
            _messageProducer = messageProducer;
        }
        public async Task CreateUserUsingMassTransit(UserDto userDto)
        {
            var user = await Save(userDto).ConfigureAwait(false);
            if (user is not null)
                await _publishEndpoint.Publish<IUserCreated>(new
                {
                    user.Email,
                    user.Password,
                }).ConfigureAwait(false);
        }

        public async Task CreateUserUsingRabbitMqClient(UserDto userDto)
        {
            var user = await Save(userDto).ConfigureAwait(false);
            if (user is not null)
                _messageProducer.SendMessage(user);
        }

        private async Task<UserDto> Save(UserDto userDto)
        {
            return await Task.FromResult(new UserDto(userDto.Email, userDto.Password)).ConfigureAwait(false);
        }
    }
}
