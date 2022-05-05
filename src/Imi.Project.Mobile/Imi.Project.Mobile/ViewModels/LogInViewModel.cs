﻿using FreshMvvm;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
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
        public override void Init(object initData)
        {
            base.Init(initData);
        }
        public async Task GetLogInJwt()
        {
            CurrentPage.IsBusy = true;
            try
            {
                var response = await _authApiService.LogInGetJwtToken(userName, password);
                Preferences.Remove("JwtToken");
                Preferences.Set("JwtToken", response.JwtToken);
                await CoreMethods.PopToRoot(true);
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
        private string userName = "sfriskey13";
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                RaisePropertyChanged(nameof(UserName));
            }
        }
        private string password = "WKlYnFhm0ikG";
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
        public ICommand NavigateToRegisterPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<RegisterViewModel>();
            });
        #endregion
    }
}
