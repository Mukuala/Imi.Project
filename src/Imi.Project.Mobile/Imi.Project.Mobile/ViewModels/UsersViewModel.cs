using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class UsersViewModel: FreshBasePageModel
    {
        private readonly IApiService<UserResponseDto, UserRequestDto> _userApiService;
        public UsersViewModel(IApiService<UserResponseDto,UserRequestDto> userApiService)
        {
            _userApiService = userApiService;
        }
        public override async void Init(object initData)
        {
            base.Init(initData);
            await FillUsers();
        }

        private async Task FillUsers()
        {
            IsBusy = true;
            try
            {
                Users = null;
                var apiusers = await _userApiService.GetAllAsync();
                Users = new ObservableCollection<UserResponseDto>(apiusers);
            }
            catch (Exception ex)
            {
                await CoreMethods.DisplayAlert("Error", $"{ex.Message}", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #region Properties
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        private ObservableCollection<UserResponseDto> users;
        public ObservableCollection<UserResponseDto> Users
        {
            get { return users; }
            set
            {
                users = value;
                RaisePropertyChanged(nameof(Users));
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand => new Command(
            async () => { await FillUsers(); });
        #endregion
    }
}
