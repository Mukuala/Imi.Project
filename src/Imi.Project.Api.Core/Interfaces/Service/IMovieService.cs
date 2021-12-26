﻿using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IMovieService : IService<MovieResponseDto, MovieRequestDto>
    {
        Task<IEnumerable<MovieResponseDto>> SearchByNameAsync(string userName);
        Task<IEnumerable<MovieResponseDto>> GetMoviesByActorId(long id);
        Task<IEnumerable<MovieResponseDto>> GetMoviesByGenreId(long id);

    }
}
