using FluentValidation;
using FreshMvvm;
using Imi.Project.Common.Dtos;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using Imi.Project.Mobile.Utils;
using Imi.Project.Mobile.Validators;
using Plugin.Media;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Imi.Project.Mobile.ViewModels
{
    public class AddMovieViewModel : FreshBasePageModel
    {
        private readonly IApiService<ActorResponseDto, ActorRequestDto> _actorApiService;
        private readonly IApiService<GenreResponseDto, GenreRequestDto> _genreApiService;
        private readonly IApiService<MovieResponseDto, MovieRequestDto> _movieApiService;
        private IValidator validator;

        private byte[] ImgByteArray { get; set; }

        public AddMovieViewModel(IApiService<ActorResponseDto, ActorRequestDto> actorApiService,
            IApiService<GenreResponseDto, GenreRequestDto> genreApiService,
            IApiService<MovieResponseDto, MovieRequestDto> movieApiService)
        {
            _actorApiService = actorApiService;
            _genreApiService = genreApiService;
            _movieApiService = movieApiService;
            validator = new MovieValidator();
        }

        public override async void Init(object initData)
        {
            if (initData != null && initData.GetType() == typeof(MovieResponseDto))
            {
                Movie = (MovieResponseDto)initData;
                Title = "Edit " + Movie.Name;

                var castactors = Movie.Actors.Cast<object>();
                SelectedActors = new ObservableCollection<object>(castactors);

                var castgenres = Movie.Genres.Cast<object>();
                SelectedGenres = new ObservableCollection<object>(castgenres);
            }
            else
            {
                Movie = new MovieResponseDto { };
                Title = "Add";
            }
            await GetGenres();
            await GetActors();
        }

        private bool Validate(MovieRequestDto movie)
        {
            NameError = "";
            DescriptionError = "";

            var validationContext = new ValidationContext<MovieRequestDto>(movie);
            var validationResult = validator.Validate(validationContext);

            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(movie.Name))
                {
                    NameError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(movie.Description))
                {
                    DescriptionError = error.ErrorMessage;
                }
            }
            return validationResult.IsValid;
        }

        private async Task GetGenres()
        {
            Genres = null;
            var apigenres = await _genreApiService.GetAllAsync();
            Genres = new ObservableCollection<GenreResponseDto>(apigenres);
        }

        private async Task GetActors()
        {
            Actors = null;
            var apiactor = await _actorApiService.GetAllAsync();
            Actors = new ObservableCollection<ActorResponseDto>(apiactor);
        }

        private async Task GetImageByteArray()
        {
            MemoryStream ms = new MemoryStream();

            await CrossMedia.Current.Initialize();
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync();
            if (selectedImageFile != null)
            {
                var test = selectedImageFile.GetStream();
                var split = selectedImageFile.Path.Split('/').ToList();
                ImageName = split.LastOrDefault();
                test.CopyTo(ms);
                ImgByteArray = ms.ToArray();
            }
        }

        public async Task AddOrEdit()
        {
            MovieRequestDto movie = new MovieRequestDto
            {
                Name = Movie.Name,
                AverageRating = Movie.AverageRating,
                Id = Movie.Id,
                Description = Movie.Description,
                Duration = Movie.Duration,
                EmbeddedTrailerUrl = Movie.EmbeddedTrailerUrl,
                ReleaseDate = Movie.ReleaseDate
            };

            if (SelectedActors != null)
            {
                var actorsSelected = SelectedActors.Cast<ActorResponseDto>();
                movie.ActorsId = actorsSelected.Select(x => x.Id).ToList();
            }
            if (SelectedGenres != null)
            {
                var genresSelected = SelectedGenres.Cast<GenreResponseDto>();
                movie.GenresId = genresSelected.Select(x => x.Id).ToList();
            }

            var genresSelectedCast = SelectedGenres.Cast<GenreResponseDto>();
            if (Movie == null)
            {
                Movie = new MovieResponseDto();
            }
            if (Validate(movie))
            {
                if (Movie.Id == 0) //Add
                {
                    var newActor = await _movieApiService.PostCallApi(movie, Preferences.Get("JwtToken", null));
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        await _movieApiService.PostImageAsync(ImgByteArray, imageName, newActor.Id.ToString(), Preferences.Get("JwtToken", null));
                    }
                    await CoreMethods.PopPageModel();
                }
                else // Edit
                {
                    await _movieApiService.PutCallApi(movie.Id.ToString(), movie, Preferences.Get("JwtToken", null));
                    if (!string.IsNullOrEmpty(imageName))
                    {
                        await _movieApiService.PostImageAsync(ImgByteArray, imageName, movie.Id.ToString(), Preferences.Get("JwtToken", null));
                    }
                    await CoreMethods.PopPageModel();
                }
            }
        }

        #region Properties

        private string imageName;
        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                RaisePropertyChanged(nameof(ImageName));
            }
        }

        private string nameError;
        public string NameError
        {
            get { return nameError; }
            set
            {
                nameError = value;
                RaisePropertyChanged(nameof(NameError));
            }
        }
        private string descriptionError;
        public string DescriptionError
        {
            get { return descriptionError; }
            set
            {
                descriptionError = value;
                RaisePropertyChanged(nameof(DescriptionError));
            }
        }

        private ObservableCollection<object> selectedActors = new ObservableCollection<object>();

        public ObservableCollection<object> SelectedActors
        {
            get { return selectedActors; }
            set
            {
                selectedActors = value;
                RaisePropertyChanged(nameof(SelectedActors));
            }
        }

        private ObservableCollection<object> selectedGenres = new ObservableCollection<object>();

        public ObservableCollection<object> SelectedGenres
        {
            get { return selectedGenres; }
            set
            {
                selectedGenres = value;
                RaisePropertyChanged(nameof(SelectedGenres));
            }
        }


        private ObservableCollection<ActorResponseDto> actors;
        public ObservableCollection<ActorResponseDto> Actors
        {
            get { return actors; }
            set
            {
                actors = value;
                RaisePropertyChanged(nameof(Actors));
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
        #endregion

        #region Commands
        public ICommand AddOrEditCommand => new Command(
     async () =>
     {
         await AddOrEdit();
     });

        public ICommand AddImage => new Command(
     async () =>
     {
         await GetImageByteArray();
     });


        #endregion

    }
}
