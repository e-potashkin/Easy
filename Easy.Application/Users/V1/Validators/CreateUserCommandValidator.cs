using Easy.Application.Users.V1.Commands;
using FluentValidation;

namespace Easy.Application.Users.V1.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.FirstName).NotNull().Length(0, 50);
            RuleFor(v => v.LastName).NotNull().Length(0, 50);
        }
    }
}