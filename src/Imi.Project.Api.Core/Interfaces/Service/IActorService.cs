using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IActorService : IService<ActorResponseDto, ActorRequestDto>
    {
        Task<IEnumerable<ActorResponseDto>> SearchByNameAsync(string userName);
    }
}
