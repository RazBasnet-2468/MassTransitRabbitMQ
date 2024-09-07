using Producer.DTO;

namespace Producer.Service
{
    public interface IUserServiceRabbitMqClient
    {
        Task CreateUserUsingRabbitMqClient(UserDto userDto);
    }
}
