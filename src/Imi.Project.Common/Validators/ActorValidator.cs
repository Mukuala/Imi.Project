using FluentValidation;
using Imi.Project.Common.Dtos;

namespace Imi.Project.Common.Validators
{
    public class ActorValidator : AbstractValidator<ActorRequestDto>
    {
        public ActorValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required.");

            RuleFor(x => x.Biography)
                .NotEmpty()
                .WithMessage("Biography is required.");
        }
    }
}
