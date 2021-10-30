using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IActorService:IService<ActorResponseDto,ActorRequestDto>
    {
        Task<IEnumerable<ActorResponseDto>> SearchByNameAsync(string userName);
        Task<IEnumerable<ActorResponseDto>> GetActorsFromMovieId(long id);
    }
}
