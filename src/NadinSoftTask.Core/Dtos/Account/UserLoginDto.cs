using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NadinSoftTask.Core.Dtos.Security;

public record UserLoginDto
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
}
