using Imi.Project.Common.Dtos;
using Imi.Project.Common.IPBaseUrl;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class AuthApiService: IAuthApiService
    {
        private HttpClient Client { get; set; }
        public AuthApiService()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<LoginResponseDto> LogInGetJwtToken(string username, string password)
        {
            LoginRequestDto login = new LoginRequestDto { UserName = username, Password = password };
            HttpResponseMessage response = await Client.PostAsJsonAsync("Auth/login", login);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<LoginResponseDto>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public async Task<string> Register(RegisterRequestDto newUser)
        {
            HttpResponseMessage response = await Client.PostAsJsonAsync("Auth/register", newUser);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<string>();
                return result;
            }
            else
            {
               return response.ReasonPhrase;
            }

        }

        public async Task<UserResponseDto> GetJwtUserProfile(string jwtToken)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(IPBaseAdress.ApiBaseAdressUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken);

            HttpResponseMessage response = await httpClient.GetAsync("Me/profile");
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

    }

}

