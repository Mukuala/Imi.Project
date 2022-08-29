using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IGenreApiService:IApiService<GenreResponseDto,GenreRequestDto>
    {
        Task<IEnumerable<MovieResponseDto>> GetMoviesByGenreId(int genreId);
    }
}
