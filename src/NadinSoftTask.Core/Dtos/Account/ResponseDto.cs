namespace NadinSoftTask.Core.Dtos.Security;

public record ResponseDto
{
    public string Status { get; set; } = default!;
    public string Message { get; set; } = default!;
}
