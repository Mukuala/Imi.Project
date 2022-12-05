using FluentValidation;
using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Common.Validators;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Plugin.Media;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class AddActorViewModel : FreshBasePageModel
    {
        private readonly IApiService<ActorResponseDto, ActorRequestDto> _apiService;

        private byte[] ImgByteArray { get; set; }
        private IValidator validator;

        public AddActorViewModel(IApiService<ActorResponseDto, ActorRequestDto> apiService)
        {
            _apiService = apiService;
            validator = new ActorValidator();
        }
        public async override void Init(object initData)
        {
            if (initData != null && initData.GetType() == typeof(int))
            {
                string id = initData.ToString();
                Actor = await _apiService.GetByIdAsync(id);
                Title = $"Edit {Actor.Name}";
            }
            else
            {
                Actor = new ActorResponseDto { };
                Title = "Add new actor";
            }
            base.Init(initData);
        }
        private bool Validate(ActorRequestDto actor)
        {
            NameError = "";
            BiographyError = "";

            var validationContext = new ValidationContext<ActorRequestDto>(actor);
            var validationResult = validator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(actor.Name))
                {
                    NameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(actor.Biography))
                {
                    BiographyError = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private async Task AddOrEdit()
        {
            ActorRequestDto actor = new ActorRequestDto
            {
                Biography = Actor.Biography,
                DateOfBirth = Actor.DateOfBirth,
                Id = Actor.Id,
                Name = Actor.Name
            };

            if (Validate(actor))
            {
                //Add
                if (Actor.Id == 0)
                {
                    var newActor = await _apiService.PostCallApi(actor, Preferences.Get("JwtToken", null));
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        await _apiService.PostImageAsync(ImgByteArray, imageName, newActor.Id.ToString(), Preferences.Get("JwtToken", null));
                    }
                    await CoreMethods.PopPageModel();
                }
                else //Edit
                {
                    await _apiService.PutCallApi(actor.Id.ToString(), actor, Preferences.Get("JwtToken", null));
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        await _apiService.PostImageAsync(ImgByteArray, imageName, actor.Id.ToString(), Preferences.Get("JwtToken", null));
                    }
                    await CoreMethods.PopPageModel();
                }
            }
        }
        private async Task GetImageByteArray()
        {
            MemoryStream ms = new MemoryStream();

            await CrossMedia.Current.Initialize();
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync();
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
        private ActorResponseDto actor;
        public ActorResponseDto Actor
        {
            get { return actor; }
            set
            {
                actor = value;
                RaisePropertyChanged(nameof(Actor));
            }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
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
        private string nameError;
        public string NameError
        {
            get { return nameError; }
            set
            {
                nameError = value;
                RaisePropertyChanged(nameof(NameError));
            }
        }
        private string biographyError;
        public string BiographyError
        {
            get { return biographyError; }
            set
            {
                biographyError = value;
                RaisePropertyChanged(nameof(BiographyError));
            }
        }
        #endregion
        #region Commands
        public ICommand AddOrEditCommand => new Command(
            async () =>
            {
                await AddOrEdit();
            });
        public ICommand AddImage => new Command(
             async () =>
             {
                 await GetImageByteArray();
             });

        #endregion
    }
}

