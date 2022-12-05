using FluentValidation;
using Imi.Project.Common.Dtos;

namespace Imi.Project.Common.Validators
{
    public class MovieValidator : AbstractValidator<MovieRequestDto>
    {
        public MovieValidator()
        {
            RuleFor(movieRequestDto => movieRequestDto.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required.");
        }
    }
}
