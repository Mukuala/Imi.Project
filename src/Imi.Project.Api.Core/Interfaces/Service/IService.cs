using Imi.Project.Common.Dtos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IService<TResponse, Trequest> where TResponse : BaseDto where Trequest : BaseDto
    {
        Task<IEnumerable<TResponse>> ListAllAsync();
        Task<TResponse> GetByIdAsync(int id);
        Task<TResponse> AddAsync(Trequest RequestDto);
        Task<TResponse> UpdateAsync(Trequest RequestDto);
        Task DeleteAsync(int id);

    }
}
