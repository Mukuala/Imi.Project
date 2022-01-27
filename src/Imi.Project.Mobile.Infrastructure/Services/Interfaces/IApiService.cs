using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IApiService<TResponseDto, TRequestDto>
    {
        Task<IEnumerable<TResponseDto>> GetAllAsync();
        Task<TResponseDto> GetByIdAsync(string id);
        Task PutCallApi(string entityId, TRequestDto entity, string jwtToken);
        Task PostCallApi(TRequestDto entity, string jwtToken);
        Task DeleteCallApi(string entityId, string jwtToken);
    }
}
