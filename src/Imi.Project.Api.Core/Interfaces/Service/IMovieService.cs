using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IMovieService : IService<MovieResponseDto, MovieRequestDto, int>
    {
        Task<IEnumerable<MovieResponseDto>> SearchByNameAsync(string userName);
        Task<IEnumerable<MovieResponseDto>> GetMoviesByActorId(int id);
        Task<IEnumerable<MovieResponseDto>> GetMoviesByGenreId(int id);

    }
}
