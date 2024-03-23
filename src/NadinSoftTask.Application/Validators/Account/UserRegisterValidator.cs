using FluentValidation;
using NadinSoftTask.Core.Dtos.Security;

namespace NadinSoftTask.Application.Validators.Account;

public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterValidator()
    {
        RuleFor(input => input.UserName).NotEmpty()
            .MaximumLength(30)
            .Matches("^[A-Za-z][A-Za-z0-9_]{7,29}$");

        RuleFor(input => input.Password).NotEmpty().Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@$!%*?&])[A-Za-z\\d$@$!%*?&]{8,}");
        
        RuleFor(input => input.Email).NotEmpty().EmailAddress();
    }
}
