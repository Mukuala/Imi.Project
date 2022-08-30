using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MovieDetailViewModel : FreshBasePageModel
    {
        private readonly IApiService<MovieResponseDto, MovieRequestDto> _apiService;
        private readonly IMeApiService _meApiService;

        public MovieDetailViewModel(IApiService<MovieResponseDto, MovieRequestDto> apiService, IMeApiService meApiService)
        {
            _apiService = apiService;
            _meApiService = meApiService;
        }

        public override async void Init(object initData)
        {
            var movieId = initData.ToString();
            Movie = await _apiService.GetByIdAsync(movieId);

            GenresListText = String.Join(", ", Movie.Genres.Select(g => g.Name));
            ActorsListText = String.Join(", ", Movie.Actors.Select(a => a.Name));

            var favorites = await _meApiService.GetFavoritesMovies(Preferences.Get("JwtToken", null));
            var watchlist = await _meApiService.GetWatchlistMovies(Preferences.Get("JwtToken", null));

            if (favorites.Any(m => m.Id == Movie.Id)) { IsFavorite = true; } else { IsFavorite = false;  }
            if (watchlist.Any(m => m.Id == Movie.Id)) { IsInWatchlist = true; } else { IsInWatchlist = false; }
        }

        private async Task Delete(int id)
        {
            var alert = await CoreMethods.DisplayAlert("Delete", $"Are you sure you want to delete {Movie.Name}?", "Yes", "No");
            if (alert)
            {
                await _apiService.DeleteCallApi(id.ToString(), Preferences.Get("JwtToken", null));
                await CoreMethods.PopPageModel();
            }
        }
        #region Properties
        private MovieResponseDto movie;
        public MovieResponseDto Movie
        {
            get { return movie; }
            set
            {
                movie = value;
                RaisePropertyChanged(nameof(Movie));
            }
        }
        private string genresListText;
        public string GenresListText
        {
            get { return genresListText; }
            set
            {
                genresListText = value;
                RaisePropertyChanged(nameof(GenresListText));
            }
        }
        private string actorsListText;
        public string ActorsListText
        {
            get { return actorsListText; }
            set
            {
                actorsListText = value;
                RaisePropertyChanged(nameof(ActorsListText));
            }
        }
        private bool isInWatchlist;
        public bool IsInWatchlist
        {
            get { return isInWatchlist; }
            set
            {
                isInWatchlist = value;
                RaisePropertyChanged(nameof(IsInWatchlist));
                RaisePropertyChanged(nameof(IsNotInWatchlist));
            }
        }
        public bool IsNotInWatchlist { get { return !IsInWatchlist; } }

        private bool isFavorite;
        public bool IsFavorite
        {
            get { return isFavorite; }
            set
            {
                isFavorite = value;
                RaisePropertyChanged(nameof(IsFavorite));
                RaisePropertyChanged(nameof(IsNotFavorite));
            }
        }
        public bool IsNotFavorite{get { return !IsFavorite; } }
        #endregion

        #region Commands
        public ICommand OpenAddMoviePage => new Command(
            async () =>
            {
                var amount = CurrentPage.Navigation.NavigationStack.Where(x => x is AddMoviePage).Count();
                if (amount < 1)
                {
                    await CoreMethods.PushPageModel<AddMovieViewModel>(Movie);
                }
            });
        public ICommand DeleteAlert => new Command(
            async () =>
            {
                await Delete(Movie.Id);
            });
        public ICommand AddToFavorite => new Command(
            async () =>
            {
                await _meApiService.AddToFavorite(Preferences.Get("JwtToken", null), Movie.Id);
                IsFavorite = true;
            });
        public ICommand RemoveFavorite => new Command(
            async () =>
            {
                await _meApiService.DeleteFavorite(Preferences.Get("JwtToken", null), Movie.Id);
                IsFavorite = false;
            });
        public ICommand AddToWatchlist => new Command(
            async () =>
            {
                await _meApiService.AddToWatchlist(Preferences.Get("JwtToken", null), Movie.Id);
                IsInWatchlist = true;
            });
        public ICommand RemoveWatchlist => new Command(
            async () =>
            {
                await _meApiService.DeleteWatchlist(Preferences.Get("JwtToken", null), Movie.Id);
                IsInWatchlist = false;
            });

        #endregion
    }
}
