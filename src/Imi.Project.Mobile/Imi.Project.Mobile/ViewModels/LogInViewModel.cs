using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class LogInViewModel : FreshBasePageModel
    {
        public readonly IAuthApiService _authApiService;
        public LogInViewModel(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }
        public async Task GetLogInJwt()
        {
            CurrentPage.IsBusy = true;
            try
            {
                var response = await _authApiService.LogInGetJwtToken(userName, password);
                Preferences.Set("JwtToken", response.JwtToken);
                Application.Current.MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>()) { BarBackgroundColor = Color.DarkGoldenrod, BarTextColor = Color.White };
                await CoreMethods.PushPageModel<MainViewModel>();
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                CurrentPage.IsBusy = false;
            }
        }

        #region Properties
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }
        #endregion

        #region Commands
        public ICommand LogInGetJwtToken => new Command(
            async () =>
            {
                await GetLogInJwt();
            });
        #endregion
    }
}
