using ECommerce.Core.Dtos;
using FluentValidation;

namespace ECommerce.Core.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        //Email
        RuleFor(temp => temp.Email)
            .NotEmpty().WithMessage("Email is required!")
            .EmailAddress().WithMessage("Email is not valid!");
        //Password
        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required!");
    }
}