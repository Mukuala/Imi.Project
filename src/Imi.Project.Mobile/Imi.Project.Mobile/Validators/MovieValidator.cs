using FluentValidation;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Validators
{
    public class MovieValidator: AbstractValidator<MovieRequestDto>
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
        protected override void EnsureInstanceNotNull(object instanceToValidate)
        {
            var nothing = "";

        }

    }
}
