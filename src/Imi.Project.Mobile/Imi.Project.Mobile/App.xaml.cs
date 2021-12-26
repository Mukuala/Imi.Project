using FreshMvvm;
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
            FreshIOC.Container.Register<IFavoriteService>(new ApiFavoriteService());
            FreshIOC.Container.Register<IWatchlistService>(new ApiWatchlistService());
            FreshIOC.Container.Register<IActorService>(new ApiActorService());
            FreshIOC.Container.Register<IGenreService>(new ApiGenreService());
            FreshIOC.Container.Register<IUserService>(new ApiUserService());
            FreshIOC.Container.Register<IMovieService>(new ApiMovieService());

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
