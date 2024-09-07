using System.ComponentModel.DataAnnotations;

namespace Producer.DTO
{
    public record UserCreatedDTO([Required] string Email);
}
