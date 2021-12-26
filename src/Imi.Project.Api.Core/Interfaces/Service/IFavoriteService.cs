using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IFavoriteService
    {
        Task<FavoriteResponseDto> GetByIdAsync(long id);
        Task<FavoriteResponseDto> GetByUserIdAndMovieId(string userId, long movieId);
        Task<FavoriteResponseDto> AddFavoriteAsync(FavoriteRequestDto favoriteRequestDto);
        Task DeleteFavoriteAsync(FavoriteRequestDto favoriteRequestDto);
        Task<IEnumerable<FavoriteResponseDto>> GetFavoritesByUserId(string userId);

    }
}
