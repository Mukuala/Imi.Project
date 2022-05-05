using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Pages;
using Imi.Project.Mobile.Utils;
using System;
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
        private readonly IApiService<GenreResponseDto, GenreRequestDto> _genreApiService;
        private readonly IAuthApiService _authApiService;

        public MainViewModel(IApiService<MovieResponseDto, MovieRequestDto> movieApiService,
            IApiService<GenreResponseDto, GenreRequestDto> genreApiService,
            IAuthApiService authApiService)
        {
            _authApiService = authApiService;
            _movieApiService = movieApiService;
            _genreApiService = genreApiService;
        }

        public override async void Init(object initData)
        {
            var user = await _authApiService.GetJwtUserProfile(GetJwtToken.JwtToken);
            if (user == null)
            {
                await CoreMethods.PushPageModel<LogInViewModel>(null);
            }
            base.Init(initData);
            await FillMovies();
        }
        public override async void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
            await FillMovies();
        }

        private async void NavigateToMovieDetailPage(MovieResponseDto movie)
        {
            await CoreMethods.PushPageModel<MovieDetailViewModel>(movie);
        }
        private async Task Search()
        {
            var apimovies = await _movieApiService.GetAllAsync();
            var foundMovies = apimovies.Where(m => m.Name.ToUpper().Contains(SearchText.ToUpper()));
            Movies = new ObservableCollection<MovieResponseDto>(foundMovies);
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
                    NavigateToMovieDetailPage(SelectedMovie);
                RaisePropertyChanged(nameof(SelectedMovie));
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
        //public ICommand OpenNavigationPage => new Command(
        //    async () =>
        //    {
        //        await CoreMethods.PushPageModel<NavigationViewModel>();
        //    });
        public ICommand SignOut => new Command(
            async () =>
            {
                Preferences.Remove("JwtToken");
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
