using Imi.Project.Common.Dtos;
using Imi.Project.Common.IPBaseUrl;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class GenreApiService : ApiService<GenreResponseDto, GenreRequestDto>, IGenreApiService
    {
        public async Task<IEnumerable<MovieResponseDto>> GetMoviesByGenreId(int genreId)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl + $"Genres/{genreId}/movies");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            IEnumerable<MovieResponseDto> movies = null;

            using (HttpResponseMessage response = await httpClient.GetAsync(""))
            {
                if (response.IsSuccessStatusCode)
                {
                    movies = await response.Content.ReadAsAsync<IEnumerable<MovieResponseDto>>();
                }
                return movies;
            };

            //var result = await httpClient.GetFromJsonAsync<IEnumerable<MovieResponseDto>>(genreId.ToString());
            //return result;
        }
    }
}
