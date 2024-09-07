using System.ComponentModel.DataAnnotations;

namespace Producer.DTO
{
    public record UserDto([Required] string Email, [Required] string Password);
}
