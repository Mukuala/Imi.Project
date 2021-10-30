using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IService<TResponse, Trequest> where TResponse : BaseDto where Trequest : BaseDto
    {
        Task<IEnumerable<TResponse>> ListAllAsync();
        Task<TResponse> GetByIdAsync(long id);
        Task<TResponse> AddAsync(Trequest RequestDto);
        Task<TResponse> UpdateAsync(Trequest RequestDto);
        Task DeleteAsync(long id);

    }
}
