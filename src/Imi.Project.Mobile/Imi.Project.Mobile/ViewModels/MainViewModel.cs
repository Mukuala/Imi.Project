using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
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

        public MainViewModel(IApiService<MovieResponseDto, MovieRequestDto> movieApiService, IApiService<GenreResponseDto, GenreRequestDto> genreApiService)
        {
            _movieApiService = movieApiService;
            _genreApiService = genreApiService;
        }

        public override async void Init(object initData)
        {
                base.Init(initData);
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
        public ICommand OpenNavigationPage => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<NavigationViewModel>();
            });
        public ICommand SearchItem => new Command(
            async () =>
            {
                await Search();
            });
        #endregion

    }
}
