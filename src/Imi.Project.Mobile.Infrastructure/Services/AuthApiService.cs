using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class AuthApiService
    {
        private HttpClient Client { get; set; }
        public AuthApiService()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://localhost:5001/api/");
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<LoginResponseDto> LogInGetJwtToken()
        {
            LoginRequestDto login = new LoginRequestDto { Password = "WKlYnFhm0ikG", UserName = "sfriskey13" };

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
        public async Task<UserResponseDto> GetJwtUserProfile(string jwtToken)
        {
            HttpResponseMessage response = await Client.GetAsync("https://localhost:5001/api/Me/profile");
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

