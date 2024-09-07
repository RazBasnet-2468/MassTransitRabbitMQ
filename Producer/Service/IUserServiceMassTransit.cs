using Producer.DTO;

namespace Producer.Service
{
    public interface IUserServiceMassTransit
    {
        Task CreateUserUsingMassTransit(UserDto userDto);
    }
}
