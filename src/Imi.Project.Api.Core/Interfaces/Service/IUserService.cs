using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> ListAllAsync();
        Task<UserResponseDto> GetByIdAsync(string id);
        Task<UserResponseDto> AddAsync(UserRequestDto userRequestDto);
        Task<UserResponseDto> UpdateAsync(UserRequestDto userRequestDto);
        Task DeleteAsync(string id);
        Task<IEnumerable<UserResponseDto>> SearchByUserNameAsync(string userName);

    }
}
