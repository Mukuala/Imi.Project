using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.Utils;
using Imi.Project.Mobile.ViewModels;
using Xamarin.Forms;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI4MDY5QDMxMzkyZTMzMmUzMFBWeTBFWHhOcWZ3d1VoZDhmTDZlSzFLaEYvam94eFpUVDdSVjhydXg5Yzg9; NTI4MDcwQDMxMzkyZTMzMmUzMGg1bGh6eWg2eWdmMFZkeEtvZVczNGFtalNqRUtiUTMrK3JSazI3bnU3OUU9; NTI4MDcxQDMxMzkyZTMzMmUzMEtHYUJSWHJXVDhRdzVtNG4ySUNjOVVaMjZOWWJEbUdUVEplRlVYWW51NDA9");
            InitializeComponent();
            FreshIOC.Container.Register<IApiService<MovieResponseDto, MovieRequestDto>>(new ApiService<MovieResponseDto, MovieRequestDto>());
            FreshIOC.Container.Register<IApiService<ActorResponseDto, ActorRequestDto>>(new ApiService<ActorResponseDto, ActorRequestDto>());
            FreshIOC.Container.Register<IApiService<UserResponseDto, UserRequestDto>>(new ApiService<UserResponseDto, UserRequestDto>());
            FreshIOC.Container.Register<IApiService<GenreResponseDto, GenreRequestDto>>(new ApiService<GenreResponseDto, GenreRequestDto>());
            FreshIOC.Container.Register<IAuthApiService>(new AuthApiService());

            if (!string.IsNullOrWhiteSpace(GetJwtToken.JwtToken))
            {
                MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>()) { BarBackgroundColor = Color.DarkGoldenrod, BarTextColor = Color.White, BackgroundColor = Color.Wheat };
            }
            else
            {
                MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<LogInViewModel>()) { BarBackgroundColor = Color.White, BarTextColor = Color.White, BackgroundColor = Color.Wheat };
            }
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
