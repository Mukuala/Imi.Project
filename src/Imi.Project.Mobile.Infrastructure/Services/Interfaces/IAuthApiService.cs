using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IAuthApiService
    {
        Task<LoginResponseDto> LogInGetJwtToken(string username,string password);
        Task<string> Register(RegisterRequestDto newUser);
    }
}
