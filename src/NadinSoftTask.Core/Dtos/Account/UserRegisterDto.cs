using System.ComponentModel.DataAnnotations;

namespace NadinSoftTask.Core.Dtos.Security;

public record UserRegisterDto
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public string Password { get; set; } = default!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;
}
