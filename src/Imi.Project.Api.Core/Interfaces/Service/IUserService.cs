using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IUserService : IService<UserResponseDto, UserRequestDto,string>
    {
        Task<IEnumerable<UserResponseDto>> SearchByUserNameAsync(string userName);
    }
}
