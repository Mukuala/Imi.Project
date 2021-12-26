using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Imi.Project.Common.Dtos;
using Imi.Project.Wpf.Core.Entities;
using Newtonsoft.Json;

namespace Imi.Project.Wpf.Infrastructure
{
    public class WebApiClient
    {
        public HttpClient Client { get; set; }
        public WebApiClient()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        private JsonMediaTypeFormatter GetJsonFormatter()
        {
            var formatter = new JsonMediaTypeFormatter();
            //prevent self-referencing loops when saving Json (Bucket -> BucketItem -> Bucket -> ...)
            formatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return formatter;
        }


        public async Task<LoginResponseDto> Authenticate(string username, string password)
        {
            LoginRequestDto login = new LoginRequestDto { Password = password, UserName = username };

            using (HttpResponseMessage httpResponse = await Client.PostAsJsonAsync("Auth/login", login))
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsAsync<LoginResponseDto>();
                    return result;
                }
                else
                {
                    throw new Exception(httpResponse.ReasonPhrase);
                }
            };
        }

        public async Task<ICollection<MovieResponseDto>> GetAllAsync()
        {
            ICollection<MovieResponseDto> movies = null;
            using (HttpResponseMessage response = await Client.GetAsync("Movies"))
            {
                if (response.IsSuccessStatusCode)
                {
                    movies = await response.Content.ReadAsAsync<ICollection<MovieResponseDto>>();
                }
                return movies;
            };
        }

        public async Task<MovieResponseDto> GetByIdAsync(long id)
        {
            MovieResponseDto movie = null;
            using (HttpResponseMessage response = await Client.GetAsync("Movies/" + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    movie = await response.Content.ReadAsAsync<MovieResponseDto>();
                }
                return movie;
            }
        }
        public async Task<MovieResponseDto> AddMovieAsync(MovieRequestDto movie)
        {
            MovieResponseDto addedMovie = null;
            using (HttpResponseMessage response = await Client.PostAsync("Movies", movie, GetJsonFormatter()))
            {
                if (response.IsSuccessStatusCode)
                {
                    addedMovie = await response.Content.ReadAsAsync<MovieResponseDto>();
                    return addedMovie;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }
        }

        public async Task<MovieResponseDto> EditMovieAsync(MovieRequestDto movie)
        {
            MovieResponseDto editedMovie = null;
            using (HttpResponseMessage response = await Client.PutAsJsonAsync("Movies", movie))
            {
                if (response.IsSuccessStatusCode)
                {
                    editedMovie = await response.Content.ReadAsAsync<MovieResponseDto>();
                }
                return editedMovie;
            }
        }
        public async Task<MovieResponseDto> DeleteMovieAsync(long id)
        {
            using (HttpResponseMessage response = await Client.DeleteAsync("Movies/" + id))
            {
                MovieResponseDto movie = null;
                if (response.IsSuccessStatusCode)
                {
                    movie = await response.Content.ReadAsAsync<MovieResponseDto>();
                }
                return movie;
            }
        }

        public async Task<ICollection<ActorResponseDto>> GetAllActorsAsync()
        {
            ICollection<ActorResponseDto> actors = null;
            using (HttpResponseMessage response = await Client.GetAsync("Actors"))
            {
                if (response.IsSuccessStatusCode)
                {
                    actors = await response.Content.ReadAsAsync<ICollection<ActorResponseDto>>();
                }
                return actors;
            };

        }
        public async Task<ICollection<GenreResponseDto>> GetAllGenresAsync()
        {
            ICollection<GenreResponseDto> genres = null;
            using (HttpResponseMessage response = await Client.GetAsync("Genres"))
            {
                if (response.IsSuccessStatusCode)
                {
                    genres = await response.Content.ReadAsAsync<ICollection<GenreResponseDto>>();
                }
                return genres;
            };

        }

        //MDE versie

        public async Task<MovieResponseDto> PutCallApi(string id, MovieRequestDto entity, string jwtToken)
        {
            return await CallApi(id, entity, HttpMethod.Put, jwtToken);
        }

        public async Task<MovieResponseDto> PostCallApi(MovieRequestDto entity, string jwtToken)
        {
            return await CallApi(null, entity, HttpMethod.Post, jwtToken);
        }

        public async Task<MovieResponseDto> DeleteCallApi(string id, string jwtToken)
        {
            return await CallApi(id, null, HttpMethod.Delete, jwtToken);
        }


        private async Task<MovieResponseDto> CallApi(string id, MovieRequestDto entity, HttpMethod httpMethod, string jwtToken)
        {
            MovieResponseDto result;

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001/api/Movies/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);
            {

                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Post)
                {
                    response = await httpClient.PostAsync("", entity, GetJsonFormatter());
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    response = await httpClient.PutAsync(id, entity, GetJsonFormatter());
                }
                else
                {
                    response = await httpClient.DeleteAsync(id);
                }
                result = await response.Content.ReadAsAsync<MovieResponseDto>();
                var status = response.StatusCode;
            }
            return result;
        }
    }
}

