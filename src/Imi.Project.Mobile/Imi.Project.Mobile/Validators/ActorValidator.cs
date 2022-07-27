using FluentValidation;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Validators
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
