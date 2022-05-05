using FluentValidation;
using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class RegisterViewModel : FreshBasePageModel
    {
        private readonly IAuthApiService _authApiService;
        private IValidator validator;
        public RegisterViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
            validator = new RegisterValidator();
        }

        private bool Validate(RegisterRequestDto user)
        {
            UserNameError = "";
            FirstNameError = "";
            LastNameError = "";
            EmailError = "";
            PasswordError = "";
            PasswordConfirmError = "";

            var validationContext = new ValidationContext<RegisterRequestDto>(user);
            var validationResult = validator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(user.UserName))
                {
                    UserNameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.FirstName))
                {
                    FirstNameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.LastName))
                {
                    LastNameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.Email))
                {
                    EmailError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.Password))
                {
                    PasswordError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(user.PasswordConfirm))
                {
                    PasswordConfirmError = error.ErrorMessage;
                }
            }

            return validationResult.IsValid;
        }

        private async Task Register()
        {
            //try
            //{
                if (Validate(User))
                {
                    await _authApiService.Register(User);
                    await CoreMethods.DisplayAlert("Succesfully registered", "You can now log in.", "Ok");
                    await CoreMethods.PopPageModel();
                }
            //}
            //catch (Exception ex)
            //{
            //    await CoreMethods.DisplayAlert("Error", ex.Message, "Ok");
            //}

        }

        #region Properties
        private RegisterRequestDto user = new RegisterRequestDto();
        public RegisterRequestDto User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged(nameof(User));
            }
        }
        private string userNameError;
        public string UserNameError
        {
            get { return userNameError; }
            set
            {
                userNameError = value;
                RaisePropertyChanged(nameof(UserNameError));
            }
        }
        private string firstNameError;
        public string FirstNameError
        {
            get { return firstNameError; }
            set
            {
                firstNameError = value;
                RaisePropertyChanged(nameof(FirstNameError));
            }
        }
        private string lastNameError;
        public string LastNameError
        {
            get { return lastNameError; }
            set
            {
                lastNameError = value;
                RaisePropertyChanged(nameof(LastNameError));
            }
        }
        private string emailError;
        public string EmailError
        {
            get { return emailError; }
            set
            {
                emailError = value;
                RaisePropertyChanged(nameof(EmailError));
            }
        }
        private string passwordError;
        public string PasswordError
        {
            get { return passwordError; }
            set
            {
                passwordError = value;
                RaisePropertyChanged(nameof(PasswordError));
            }
        }
        private string passwordConfirmError;
        public string PasswordConfirmError
        {
            get { return passwordConfirmError; }
            set
            {
                passwordConfirmError = value;
                RaisePropertyChanged(nameof(PasswordConfirmError));
            }
        }
        #endregion

        #region Commands
        public ICommand RegisterCommand => new Command(
            async () =>
            {
                await Register();
            });
        public ICommand NavigateToLogin => new Command(
            async () =>
            {
                await CoreMethods.PopPageModel();
            });
        #endregion
    }
}
