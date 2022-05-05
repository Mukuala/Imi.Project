using Imi.Project.Common.Dtos;
using Imi.Project.Common.IPBaseUrl;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ApiService<TResponseDto, TRequestDto> : IApiService<TResponseDto, TRequestDto>
    {
        private HttpClientHandler ClientHandler()
        {
            var httpClientHandler = new HttpClientHandler();
#if DEBUG
            //allow connecting to untrusted certificates when running a DEBUG assembly
            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };
#endif
            return httpClientHandler;
        }

        private HttpClient Client { get; set; }
        public ApiService()
        {
            Client = new HttpClient(ClientHandler());
            Client.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl + typeof(TResponseDto).Name.Replace("ResponseDto", "s/"));
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<IEnumerable<TResponseDto>> GetAllAsync()
        {
            if (typeof(TResponseDto) == typeof(UserResponseDto))
            {
                string jwtToken = Preferences.Get("JwtToken", null);
                Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            }
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
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl + typeof(TResponseDto).Name.Replace("ResponseDto", "s/"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);
            {

                if (httpMethod == HttpMethod.Post)
                {
                    var response = await httpClient.PostAsJsonAsync("", entity);
                    var responsedto = await response.Content.ReadAsAsync<TResponseDto>();
                    return responsedto;
                }
                else if (httpMethod == HttpMethod.Put)
                {
                    var response = await httpClient.PutAsJsonAsync("", entity);
                    var responsedto = await response.Content.ReadAsAsync<TResponseDto>();
                    return responsedto;
                }
                else
                {
                    await httpClient.DeleteAsync(id);
                    return default;
                }
            }
        }
        public async Task PostImageAsync(byte[] imgByteArray, string imgName, string id, string jwtToken)
        {

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl + typeof(TResponseDto).Name.Replace("ResponseDto", "s/"));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
    }
}
