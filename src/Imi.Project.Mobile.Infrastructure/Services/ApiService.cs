using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ApiService<TResponseDto, TRequestDto> : IApiService<TResponseDto, TRequestDto>
    {
        private HttpClient Client { get; set; }
        public ApiService()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/" + typeof(TResponseDto).Name.Replace("ResponseDto", "s/"));
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<IEnumerable<TResponseDto>> GetAllAsync()
        {
            //var result = await Client.GetFromJsonAsync<IEnumerable<TResponseDto>>("");
            //return result;
            IEnumerable<TResponseDto> movies = null;
            using (HttpResponseMessage response = await Client.GetAsync(""))
            {
                if (response.IsSuccessStatusCode)
                {
                    movies = await response.Content.ReadAsAsync<IEnumerable<TResponseDto>>();
                }
                return movies;
            };

        }

        public async Task<TResponseDto> GetByIdAsync(string id)
        {
            var result = await Client.GetFromJsonAsync<TResponseDto>(id);
            return result;
        }

        public async Task PutCallApi(string id, TRequestDto entity, string jwtToken)
        {
            await CallApi(id, entity, HttpMethod.Put, jwtToken);
        }

        public async Task PostCallApi(TRequestDto entity, string jwtToken)
        {
            await CallApi(null, entity, HttpMethod.Post, jwtToken);
        }

        public async Task DeleteCallApi(string id, string jwtToken)
        {
            await CallApi(id, default, HttpMethod.Delete, jwtToken);
        }


        private async Task CallApi(string id, TRequestDto entity, HttpMethod httpMethod, string jwtToken)
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            {

                if (httpMethod == HttpMethod.Post)
                {
                    await Client.PostAsJsonAsync("", entity);
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    await Client.PutAsJsonAsync("", entity);
                }
                else
                {
                    await Client.DeleteAsync(id);
                }
            }
        }
    }
}
