using FluentValidation;
using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Validators;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class EditProfileViewModel : FreshBasePageModel
    {
        private readonly IMeApiService _meApiService;
        private byte[] ImgByteArray { get; set; }
        private IValidator validator;

        public EditProfileViewModel(IMeApiService meApiService)
        {
            _meApiService = meApiService;
            validator = new ProfileValidator();
        }

        public override void Init(object initData)
        {
            if (initData != null && initData.GetType() == typeof(UserResponseDto))
            {
                User = (UserResponseDto)initData;
            }
            base.Init(initData);
        }

        private bool Validate(UserRequestDto user)
        {
            FirstNameError = "";
            LastNameError = "";
            EmailError = "";

            var validationContext = new ValidationContext<UserRequestDto>(user);
            var validationResult = validator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
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
            }
            return validationResult.IsValid;
        }

        private async Task Edit()
        {
            UserRequestDto user = new UserRequestDto
            {
                Birthday = User.Birthday,
                Email = User.Email,
                FirstName = User.FirstName,
                LastName = User.LastName,
                UserName = User.UserName,
                Id = User.Id,
                
            };
            if (Validate(user))
            {
                await _meApiService.EditProfile(user, Preferences.Get("JwtToken", null));
                if (!string.IsNullOrEmpty(imageName))
                {
                    await _meApiService.PostImageAsync(ImgByteArray, imageName, user.Id, Preferences.Get("JwtToken", null));
                }
                await CoreMethods.PopPageModel();
            }
        }

        private async Task GetImageByteArray(bool camera)
        {
            MediaFile selectedImageFile;
            MemoryStream ms = new MemoryStream();
            await CrossMedia.Current.Initialize();

            if (!camera)
            {
                selectedImageFile = await CrossMedia.Current.PickPhotoAsync();
            }
            else
            {
                selectedImageFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions());
            }
            if (selectedImageFile != null)
            {
                var test = selectedImageFile.GetStream();
                var split = selectedImageFile.Path.Split('/').ToList();
                ImageName = split.LastOrDefault();
                test.CopyTo(ms);
                ImgByteArray = ms.ToArray();
            }
        }

        #region Properties
        private UserResponseDto user;
        public UserResponseDto User
        {
            get { return user; }
            set
            {
                user = value;
                RaisePropertyChanged(nameof(User));
            }
        }

        private string imageName = "";
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                RaisePropertyChanged(nameof(ImageName));
            }
        }

        private string firstNameError = "";
        public string FirstNameError
        {
            get { return firstNameError; }
            set
            {
                firstNameError = value;
                RaisePropertyChanged(nameof(FirstNameError));
            }
        }

        private string lastNameError = "";
        public string LastNameError
        {
            get { return lastNameError; }
            set
            {
                lastNameError = value;
                RaisePropertyChanged(nameof(LastNameError));
            }
        }

        private string emailError = "";
        public string EmailError
        {
            get { return emailError; }
            set
            {
                emailError = value;
                RaisePropertyChanged(nameof(EmailError));
            }
        }
        #endregion

        #region Commands
        public ICommand AddImageByCamera => new Command(
            async () =>
            {
                await GetImageByteArray(true);
            });

        public ICommand AddImageByGallery => new Command(
            async () =>
            {
                await GetImageByteArray(false);
            });

        public ICommand EditCommand => new Command(
            async () =>
            {
                await Edit();
            });
        #endregion

    }
}
