using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class ProfileViewModel : FreshBasePageModel
    {
        

        private readonly IMeApiService _meApiService;
        public ProfileViewModel(IMeApiService meApiService)
        {
            _meApiService = meApiService;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await GetUserProfile();
        }

        private async Task GetUserProfile()
        {
            AmountOfFavorites = 0;
            AmountOfWatchlist = 0;
            User = await _meApiService.GetJwtUserProfile(Preferences.Get("JwtToken", null));
            AmountOfFavorites = User.FavoritesMovies.Count;
            AmountOfWatchlist = User.WatchlistMovies.Count;
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
        private int amountOfFavorites;
        public int AmountOfFavorites
        {
            get { return amountOfFavorites; }
            set
            {
                amountOfFavorites = value;
                RaisePropertyChanged(nameof(AmountOfFavorites));
            }
        }
        private int amountOfWatchlist;
        public int AmountOfWatchlist
        {
            get { return amountOfWatchlist; }
            set
            {
                amountOfWatchlist = value;
                RaisePropertyChanged(nameof(AmountOfWatchlist));
            }
        }
        #endregion

        #region Commands
        public ICommand OpenEditProfilePage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<EditProfileViewModel>(User);
            });
        #endregion
    }
}
