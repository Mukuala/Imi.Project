using Imi.Project.Common.Dtos;
using Imi.Project.Common.IPBaseUrl;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class MeApiService : IMeApiService
    {
        HttpClient httpClient = new HttpClient();

        public MeApiService()
        {
            httpClient.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl + "Me/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<IEnumerable<MovieResponseDto>> GetFavoritesMovies(string jwtToken)
        {
            return await GetUserMovies(jwtToken, "favorites");
        }
        public async Task AddToFavorite(string jwtToken, int movieId)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await httpClient.PostAsJsonAsync("favorites", movieId);
        }
        public async Task DeleteFavorite (string jwtToken, int movieId)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await httpClient.DeleteAsync("favorites/"+ movieId);
        }
        public async Task<IEnumerable<MovieResponseDto>> GetWatchlistMovies(string jwtToken)
        {
            return await GetUserMovies(jwtToken, "watchlists");
        }
        public async Task AddToWatchlist(string jwtToken, int movieId)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await httpClient.PostAsJsonAsync("watchlists",movieId);
        }
        public async Task DeleteWatchlist(string jwtToken, int movieId)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            var response = await httpClient.DeleteAsync("watchlists/" + movieId);
        }

        public async Task EditProfile(UserRequestDto user, string jwtToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            var response = await httpClient.PutAsJsonAsync("", user);
            //var responsedto = await response.Content.ReadAsAsync<UserResponseDto>();
            //return responsedto;

        }
        public async Task PostImageAsync(byte[] imgByteArray, string imgName, string id, string jwtToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            using (var form = new MultipartFormDataContent())
            {
                using (var stream = new MemoryStream(imgByteArray))
                {
                    form.Add(new StreamContent(stream), "Image", imgName);
                    await httpClient.PostAsync(id + "/image", form);
                }
            }
        }


        public async Task<UserResponseDto> GetJwtUserProfile(string jwtToken)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            HttpResponseMessage response = await httpClient.GetAsync("profile");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<UserResponseDto>();
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else throw new Exception(response.ReasonPhrase);
        }
        private async Task<IEnumerable<MovieResponseDto>> GetUserMovies(string jwtToken, string getAsyncUri)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            HttpResponseMessage response = await httpClient.GetAsync(getAsyncUri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<IEnumerable<MovieResponseDto>>();
                return result;
            }
            return null;
        }
    }
}
