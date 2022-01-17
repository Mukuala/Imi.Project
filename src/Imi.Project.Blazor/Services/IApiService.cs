using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Imi.Project.Blazor.Services
{
    public interface IApiService<TResponseDto, TRequestDto>
    {
        Task<IEnumerable<TResponseDto>> GetAllAsync();
        Task<TResponseDto> GetByIdAsync(string id);
        Task<TResponseDto> PutCallApi(string entityId, TRequestDto entity, string jwtToken);
        Task<TResponseDto> PostCallApi(TRequestDto entity, string jwtToken);
        Task DeleteCallApi(string entityId, string jwtToken);
        Task<LoginResponseDto> LogInGetJwtToken();
        Task<UserResponseDto> GetJwtUserProfile(string jwtToken);
        Task PostImageAsync(byte[] imgByteArray, string imgName, int movieId);
    }
}
