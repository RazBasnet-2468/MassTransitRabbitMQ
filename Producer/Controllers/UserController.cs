using Microsoft.AspNetCore.Mvc;
using Producer.DTO;
using Producer.Service;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController(IUserServiceMassTransit massTransitService, IUserServiceRabbitMqClient rabbitMqClientService) : ControllerBase
    {

        [HttpPost("CreateUser")]
        public ActionResult CreateUser(UserDto dto)
        {
            massTransitService.CreateUserUsingMassTransit(dto).ConfigureAwait(false);
            return Ok("Execute Successfully");
        }

        [HttpPost("SaveUser")]
        public ActionResult SaveUser(UserDto dto)
        {
            rabbitMqClientService.CreateUserUsingRabbitMqClient(dto).ConfigureAwait(false);
            return Ok("Execute Successfully");
        }
    }
}
