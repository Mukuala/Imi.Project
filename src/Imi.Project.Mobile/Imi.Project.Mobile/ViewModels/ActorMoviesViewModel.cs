using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.ViewModels
{
    public class ActorMoviesViewModel : FreshBasePageModel
    {
        private readonly IApiService<ActorResponseDto,ActorRequestDto> _actorApiService;

        public ActorMoviesViewModel(IApiService<ActorResponseDto, ActorRequestDto> actorApiService)
        {
            _actorApiService = actorApiService;
        }
        public override async void Init(object initData)
        {
            if (initData != null && initData.GetType() == typeof(int))
            {
                string id = initData.ToString();
                Actor = await _actorApiService.GetByIdAsync(id);
                Title = $"{Actor.Name} movies";
            }

            base.Init(initData);
        }
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await FillActorsMovies();
        }

        private async Task FillActorsMovies()
        {
            IsBusy = true;
            try
            {
                HasNoMovies = false;
                Movies = null;
                var apimovies = Actor.Movies;
                if (apimovies.ToList().Count > 0)
                {
                    Movies = new ObservableCollection<MovieResponseDto>(apimovies);
                }
                else { HasNoMovies = true; }
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
        private async void NavigateToMovieDetailPage(int movieId)
        {
            await CoreMethods.PushPageModel<MovieDetailViewModel>(movieId);
        }


        #region Properties
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        private ActorResponseDto actor;
        public ActorResponseDto Actor
        {
            get { return actor; }
            set
            {
                actor = value;
                RaisePropertyChanged(nameof(Actor));
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
        private bool hasNoMovies = false;
        public bool HasNoMovies
        {
            get { return hasNoMovies; }
            set
            {
                hasNoMovies = value;
                RaisePropertyChanged(nameof(HasNoMovies));
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
        #endregion
    }
}
