using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private readonly IApiService<MovieResponseDto, MovieRequestDto> _movieApiService;
        private readonly IGenreApiService _genreApiService;
        private readonly IMeApiService _meApiService;

        public MainViewModel(IApiService<MovieResponseDto, MovieRequestDto> movieApiService,
            IGenreApiService genreApiService,
            IMeApiService meApiService)
        {
            _meApiService = meApiService;
            _movieApiService = movieApiService;
            _genreApiService = genreApiService;
        }

        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            var user = await _meApiService.GetJwtUserProfile(Preferences.Get("JwtToken", null));
            if (user == null)
            {
                await CoreMethods.PushPageModel<LogInViewModel>(null);
            }
            base.ViewIsAppearing(sender, e);
            await FillMovies();
        }
        //public override async void Init(object initData)
        //{
        //    var user = await _meApiService.GetJwtUserProfile(Preferences.Get("JwtToken", null));
        //    if (user == null)
        //    {
        //        await CoreMethods.PushPageModel<LogInViewModel>(null);
        //    }
        //    base.Init(initData);
        //    await FillMovies();
        //}
        private async void ShowSpecificGenreMovies(int genreId)
        {

            var movies = await _genreApiService.GetMoviesByGenreId(genreId);
            Movies = new ObservableCollection<MovieResponseDto>(movies);

        }
        private async void NavigateToMovieDetailPage(int movieId)
        {
            await CoreMethods.PushPageModel<MovieDetailViewModel>(movieId);
        }
        private async Task Search()
        {
            var apimovies = await _movieApiService.GetAllAsync(SearchText);

            if (apimovies != null)
                Movies = new ObservableCollection<MovieResponseDto>(apimovies);
            else
                Movies = null;

        }
        private async Task FillMovies()
        {
            IsBusy = true;
            try
            {
                Movies = null;
                var apimovies = await _movieApiService.GetAllAsync();
                Movies = new ObservableCollection<MovieResponseDto>(apimovies);

                var apigenres = await _genreApiService.GetAllAsync();
                Genres = new ObservableCollection<GenreResponseDto>(apigenres);
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

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                RaisePropertyChanged(nameof(searchText));
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
        private GenreResponseDto selectedGenre;
        public GenreResponseDto SelectedGenre
        {
            get
            {
                return selectedGenre;
            }
            set
            {
                selectedGenre = value;

                if (selectedGenre == null)
                    FillMovies();
                else
                    ShowSpecificGenreMovies(selectedGenre.Id);
                RaisePropertyChanged(nameof(SelectedGenre));
            }
        }

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

        private ObservableCollection<GenreResponseDto> genres;
        public ObservableCollection<GenreResponseDto> Genres
        {
            get { return genres; }
            set
            {
                genres = value;
                RaisePropertyChanged(nameof(Genres));
            }
        }
        #endregion


        #region Commands

        public ICommand RefreshCommand => new Command(
            async () =>
            {
                await FillMovies();
            });
        public ICommand SignOut => new Command(
            async () =>
            {
                Preferences.Clear();
                var test = Preferences.Get("JwtToken", null);

                await CoreMethods.PushPageModel<LogInViewModel>(null);
            });
        public ICommand SearchItem => new Command(
            async () =>
            {
                await Search();
            });
        public ICommand OpenAddMoviePage => new Command(
            async () =>
            {
                var amount = CurrentPage.Navigation.NavigationStack.Where(x => x is AddMoviePage).Count();
                if (amount < 1)
                {
                    await CoreMethods.PushPageModel<AddMovieViewModel>();
                }
            });
        #endregion

    }
}
