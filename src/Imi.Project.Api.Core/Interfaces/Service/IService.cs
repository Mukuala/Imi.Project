using Imi.Project.Common.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IService<TResponse, TRequest, TBaseDtoKey> where TResponse : BaseDto<TBaseDtoKey> where TRequest : BaseDto<TBaseDtoKey>
    {
        Task<IEnumerable<TResponse>> ListAllAsync();
        Task<TResponse> GetByIdAsync(TBaseDtoKey id);
        Task<TResponse> AddAsync(TRequest RequestDto);
        Task<TResponse> UpdateAsync(TRequest RequestDto);
        Task DeleteAsync(TBaseDtoKey id);
    }
}
