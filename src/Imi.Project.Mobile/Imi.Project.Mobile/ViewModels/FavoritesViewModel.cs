using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class FavoritesViewModel : FreshBasePageModel
    {
        private readonly IMeApiService _meApiService;

        public FavoritesViewModel(IMeApiService meApiService)
        {
            _meApiService = meApiService;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await FillFavoriteMovies();
        }
        private async void NavigateToMovieDetailPage(int movieId)
        {
            await CoreMethods.PushPageModel<MovieDetailViewModel>(movieId);
        }
        private async Task FillFavoriteMovies()
        {
            IsBusy = true;
            try
            {
                HasNoFavorites = false;
                Movies = null;
                var apimovies = await _meApiService.GetFavoritesMovies(Preferences.Get("JwtToken", null));
                if (apimovies.ToList().Count > 0)
                {
                    Movies = new ObservableCollection<MovieResponseDto>(apimovies);
                }
                else { HasNoFavorites = true; }
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
        private ObservableCollection<MovieResponseDto> movies;
        public ObservableCollection<MovieResponseDto> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                RaisePropertyChanged(nameof(Movies));
            }
        }
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
        private bool hasNoFavorites = false;
        public bool HasNoFavorites
        {
            get { return hasNoFavorites; }
            set
            {
                hasNoFavorites = value;
                RaisePropertyChanged(nameof(HasNoFavorites));
            }
        }

        private MovieResponseDto selectedMovie;
        public MovieResponseDto SelectedMovie
        {
            get
            {
                return selectedMovie;
            }
            set
            {
                selectedMovie = value;
                if (SelectedMovie != null)
                    NavigateToMovieDetailPage(SelectedMovie.Id);
                RaisePropertyChanged(nameof(SelectedMovie));
            }
        }

        #endregion

        #region Commands
        public ICommand RefreshCommand => new Command(
    async () =>
    {
        await FillFavoriteMovies();
    });

        #endregion
    }
}
