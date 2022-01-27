using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI4MDY5QDMxMzkyZTMzMmUzMFBWeTBFWHhOcWZ3d1VoZDhmTDZlSzFLaEYvam94eFpUVDdSVjhydXg5Yzg9; NTI4MDcwQDMxMzkyZTMzMmUzMGg1bGh6eWg2eWdmMFZkeEtvZVczNGFtalNqRUtiUTMrK3JSazI3bnU3OUU9; NTI4MDcxQDMxMzkyZTMzMmUzMEtHYUJSWHJXVDhRdzVtNG4ySUNjOVVaMjZOWWJEbUdUVEplRlVYWW51NDA9");
            InitializeComponent();
            FreshIOC.Container.Register<IApiService<MovieResponseDto,MovieRequestDto>>(new ApiService<MovieResponseDto,MovieRequestDto>());
            FreshIOC.Container.Register<IApiService<ActorResponseDto,ActorRequestDto>>(new ApiService<ActorResponseDto,ActorRequestDto>());
            FreshIOC.Container.Register<IApiService<UserResponseDto,UserRequestDto>>(new ApiService<UserResponseDto,UserRequestDto>());
            FreshIOC.Container.Register<IApiService<GenreResponseDto,GenreRequestDto>>(new ApiService<GenreResponseDto,GenreRequestDto>());

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
