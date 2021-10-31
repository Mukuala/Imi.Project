using DLToolkit.Forms.Controls;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imi.Project.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI4MDY5QDMxMzkyZTMzMmUzMFBWeTBFWHhOcWZ3d1VoZDhmTDZlSzFLaEYvam94eFpUVDdSVjhydXg5Yzg9; NTI4MDcwQDMxMzkyZTMzMmUzMGg1bGh6eWg2eWdmMFZkeEtvZVczNGFtalNqRUtiUTMrK3JSazI3bnU3OUU9; NTI4MDcxQDMxMzkyZTMzMmUzMEtHYUJSWHJXVDhRdzVtNG4ySUNjOVVaMjZOWWJEbUdUVEplRlVYWW51NDA9");
            InitializeComponent();
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
