using Imi.Project.Blazor.Services;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
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
        protected MovieRequestDto movieRequest = new MovieRequestDto();
        protected string error;
        protected string storedToken = null;
        protected string JwtWarning = null;


        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public string Action { get; set; }
        [Parameter]
        public long MovieId { get; set; }



        [Inject]
        private IApiService<MovieResponseDto, MovieRequestDto> movieService { get; set; }
        [Inject]
        private IApiService<ActorResponseDto, ActorRequestDto> actorService { get; set; }
        [Inject]
        private IApiService<GenreResponseDto, GenreRequestDto> genreService { get; set; }
        protected override async Task OnParametersSetAsync()
        {
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
                movie = new MovieResponseDto();
                await GetActorsList();
                await GetGenresList();
            }
            else if (Action == "edit" && MovieId != 0)
            {
                await GetMovie(MovieId);
                await GetActorsList();
                await GetGenresList();

            }
        }

        public async Task GetMovieList()
        {
            var m = await movieService.GetAllAsync();
            movies = (List<MovieResponseDto>)m;
            movie = null;
        }

        public async Task GetMovie(long? id)
        {
            movie = await movieService.GetByIdAsync(id.ToString());
        }

        public async Task SaveMovie()
        {
            try
            {
                if (storedToken != null || movieRequest.Id == 0 || movieRequest.Id == null)
                {
                    await movieService.PostCallApi(movieRequest, storedToken);
                    UrlNavigationManager.NavigateTo("/movies");

                }
                else if (storedToken != null)
                {
                    await movieService.PutCallApi(movie.Id.ToString(), movieRequest, storedToken);
                    UrlNavigationManager.NavigateTo("/movies");
                }
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
                await this.GetMovieList();
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
        //private bool ValidJwtToken()
        //{
        //    if (movieService.GetJwtUserProfile(storedToken) == null)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
    }
}
