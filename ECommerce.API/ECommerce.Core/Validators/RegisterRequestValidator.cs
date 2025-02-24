using ECommerce.Core.Dtos;
using FluentValidation;

namespace ECommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //PersonName
        RuleFor(temp => temp.PersonName)
            .NotEmpty().WithMessage("Person name is required!")
            .Length(2, 50).WithMessage("Person name should strictly have 2-50 characters!");

        //Email
        RuleFor(temp => temp.Email)
            .NotEmpty().WithMessage("Email is required!")
            .Length(4, 100).WithMessage("Email should strictly have 4-100 characters!")
            .EmailAddress().WithMessage("Email is not valid!");

        //Password
        RuleFor(temp => temp.Password)
            .NotEmpty().WithMessage("Password is required!")
            .Length(2, 16).WithMessage("Password should strictly have 8-16 characters!");

        //Gender
        RuleFor(temp => temp.Gender).IsInEnum()
            .WithMessage("Gender must be Male, Female or Others!");
    }
}