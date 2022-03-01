using Imi.Project.Blazor.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Pages
{
    public partial class Movies : ComponentBase
    {
        protected List<MovieResponseDto> movies = new List<MovieResponseDto>();
        protected List<ActorResponseDto> actors = new List<ActorResponseDto>();
        protected List<GenreResponseDto> genres = new List<GenreResponseDto>();
        protected MovieResponseDto movie = null;
        protected UserResponseDto user = new UserResponseDto();
        protected MovieRequestDto movieRequest = null;
        protected byte[] imgByteArray;
        protected string imageName;
        protected string error;
        protected string storedToken = null;

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public string Action { get; set; }
        [Parameter]
        public int MovieId { get; set; }

        [Inject]
        private IApiService<MovieResponseDto, MovieRequestDto> movieService { get; set; }
        [Inject]
        private IApiService<ActorResponseDto, ActorRequestDto> actorService { get; set; }
        [Inject]
        private IApiService<GenreResponseDto, GenreRequestDto> genreService { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            imgByteArray = null;
            imageName = "";
            actorsId = null;
            genresId = null;
            if (Action == null && MovieId == 0)
            {
                await GetMovieList();
            }
            else if (Action == null && MovieId != 0)
            {
                await GetMovie(MovieId);
            }
            else if (Action == "create" && MovieId == 0)
            {
                movieRequest = new MovieRequestDto();
                await GetActorsList();
                await GetGenresList();
            }
            else if (Action == "edit" && MovieId != 0)
            {
                await GetMovie(MovieId);
                await GetActorsList();
                await GetGenresList();
                movieRequest = new MovieRequestDto
                {
                    Name = movie.Name,
                    Id = movie.Id,
                    AverageRating = movie.AverageRating,
                    Description = movie.Description,
                    Duration = movie.Duration,
                    EmbeddedTrailerUrl = movie.EmbeddedTrailerUrl,
                    ReleaseDate = movie.ReleaseDate,
                    ActorsId = movie.Actors.Select(a => a.Id).ToList(),
                    GenresId = movie.Genres.Select(g => g.Id).ToList(),
                };
                actorsId = (List<int>)movieRequest.ActorsId;
                genresId = (List<int>)movieRequest.GenresId;
            }
        }
        public async Task GetMovieList()
        {
            var m = await movieService.GetAllAsync();
            movies = (List<MovieResponseDto>)m;
            movie = null;
        }

        public async Task GetMovie(int id)
        {
            movie = await movieService.GetByIdAsync(id.ToString());
        }

        public async Task SaveMovie()
        {
            try
            {
                if (storedToken != null && movieRequest.Id == 0)
                {
                    movie = await movieService.PostCallApi(movieRequest, storedToken);
                }
                else if (storedToken != null)
                {
                    await movieService.PutCallApi(movieRequest.Id.ToString(), movieRequest, storedToken);
                }
                if (imgByteArray != null && !string.IsNullOrEmpty(imageName))
                {
                    await movieService.PostImageAsync(imgByteArray, imageName, movie.Id);
                }
                UrlNavigationManager.NavigateTo("/movies");
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task DeleteMovie(MovieResponseDto movie)
        {
            try
            {
                await movieService.DeleteCallApi(movie.Id.ToString(), storedToken);
                UrlNavigationManager.NavigateTo("/movies");
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task GetActorsList()
        {
            var a = await actorService.GetAllAsync();
            actors = (List<ActorResponseDto>)a;
        }
        public async Task GetGenresList()
        {
            var g = await genreService.GetAllAsync();
            genres = (List<GenreResponseDto>)g;
        }
    }
}
