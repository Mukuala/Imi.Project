﻿using FluentValidation;
using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Validators
{
    public class ProfileValidator: AbstractValidator<UserRequestDto>
    {
        public ProfileValidator()
        {
            RuleFor(user=>user.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");
            RuleFor(user=>user.LastName)
                .NotEmpty()
                .WithMessage("Last name is required.");
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");
        }
    }
}
