using FluentValidation;
using Imi.Project.Common.Dtos;
using System.Linq;

namespace Imi.Project.Common.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterValidator()
        {
            RuleFor(RegisterRequestDto => RegisterRequestDto.UserName)
                 .NotEmpty()
                 .WithMessage("Username is required.")
                 .Length(5, 10)
                 .WithMessage("Length must be between 5 and 15.");

            RuleFor(RegisterRequestDto => RegisterRequestDto.FirstName)
                 .NotEmpty()
                 .WithMessage("First name is required.");

            RuleFor(RegisterRequestDto => RegisterRequestDto.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(RegisterRequestDto => RegisterRequestDto.LastName)
                 .NotEmpty()
                 .WithMessage("Last name is required.");

            RuleFor(RegisterRequestDto => RegisterRequestDto.Password)
                 .NotEmpty()
                 .WithMessage("Password is required.")
                 .Must(password => PasswordRules(password))
                 .WithMessage("Password must have upper-, lowercase, number and be 6 characters long.");

            RuleFor(RegisterRequestDto => RegisterRequestDto.PasswordConfirm)
                 .Equal(x => x.Password)
                 .WithMessage("Passwords do not match.");
        }
        public bool PasswordRules(string password)
        {
            if (password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit) && password.Length > 5)
            {
                return true;
            }
            return false;
        }
    }
}