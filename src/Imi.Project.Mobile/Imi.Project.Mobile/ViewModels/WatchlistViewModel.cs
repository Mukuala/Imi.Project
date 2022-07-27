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

    public class WatchlistViewModel : FreshBasePageModel
    {


        private readonly IMeApiService _meApiService;
        public WatchlistViewModel(IMeApiService meApiService)
        {
            _meApiService = meApiService;
        }
        private async void NavigateToMovieDetailPage(int movieId)
        {
            await CoreMethods.PushPageModel<MovieDetailViewModel>(movieId);
        }
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await FillWatchlist();
        }
        private async Task FillWatchlist()
        {
            IsBusy = true;
            try
            {
                HasNoWatchlist = false;
                Movies = null;
                var apimovies = await _meApiService.GetWatchlistMovies(Preferences.Get("JwtToken", null));
                if (apimovies.ToList().Count > 0)
                {
                    Movies = new ObservableCollection<MovieResponseDto>(apimovies);
                }
                else { HasNoWatchlist = true; }
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
        private bool hasNoWatchlist = false;
        public bool HasNoWatchlist
        {
            get { return hasNoWatchlist; }
            set
            {
                hasNoWatchlist = value;
                RaisePropertyChanged(nameof(HasNoWatchlist));
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
        await FillWatchlist();
    });
        #endregion
    }
}
