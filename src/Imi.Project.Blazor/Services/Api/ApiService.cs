using Imi.Project.Common.Dtos;
using System;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Imi.Project.Blazor.Services.Api
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
        public async Task<LoginResponseDto> LogInGetJwtToken()
        {
            LoginRequestDto login = new LoginRequestDto { Password = "WKlYnFhm0ikG", UserName = "sfriskey13" };

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("https://localhost:5001/api/Auth/login", login);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<LoginResponseDto>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            };
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

        public async Task<TResponseDto> PutCallApi(string id, TRequestDto entity, string jwtToken)
        {
            return await CallApi(id, entity, HttpMethod.Put, jwtToken);
        }

        public async Task<TResponseDto> PostCallApi(TRequestDto entity, string jwtToken)
        {
            return await CallApi(null, entity, HttpMethod.Post, jwtToken);
        }

        public async Task DeleteCallApi(string id, string jwtToken)
        {
            await CallApi(id, default, HttpMethod.Delete, jwtToken);
        }


        private async Task<TResponseDto> CallApi(string id, TRequestDto entity, HttpMethod httpMethod, string jwtToken)
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            {

                if (httpMethod == HttpMethod.Post)
                {
                    var response = await Client.PostAsJsonAsync("", entity);
                    var responsedto = await response.Content.ReadAsAsync<TResponseDto>();
                    return responsedto;

                }
                else if (httpMethod == HttpMethod.Put)
                {
                    var response = await Client.PutAsJsonAsync("", entity);
                    var responsedto = await response.Content.ReadAsAsync<TResponseDto>();
                    return responsedto;

                }
                else
                {
                    await Client.DeleteAsync(id);
                    return default;
                }
            }
        }

        public async Task<UserResponseDto> GetJwtUserProfile(string jwtToken)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5001/api/Me/profile");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<UserResponseDto>();
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized && response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else throw new Exception(response.ReasonPhrase);
        }

        public async Task PostImageAsync(byte[] imgByteArray, string imgName, int movieId)
        {
            using (var form = new MultipartFormDataContent())
            {
                using (var stream = new MemoryStream(imgByteArray))
                {
                    form.Add(new StreamContent(stream), "Image", imgName);
                    using (HttpResponseMessage response = await Client.PostAsync(movieId + "/image", form))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string m = "hello";
                        }
                    }
                }
            }
        }
    }
}
