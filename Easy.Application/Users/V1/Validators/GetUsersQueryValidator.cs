using Easy.Application.Users.V1.Queries;
using FluentValidation;

namespace Easy.Application.Users.V1.Validators
{
    public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
    {
        public GetUsersQueryValidator()
        {
            RuleFor(v => v.PageSize).GreaterThan(0);
            RuleFor(v => v.PageIndex).GreaterThanOrEqualTo(0);
        }
    }
}