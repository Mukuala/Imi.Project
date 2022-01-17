using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IFavoriteService
    {
        Task<FavoriteResponseDto> GetByUserIdAndMovieId(string userId, int movieId);
        Task<FavoriteResponseDto> AddFavoriteAsync(string userId,int movieId);
        Task DeleteFavoriteAsync(string userId,int movieId);
        Task<IEnumerable<FavoriteResponseDto>> GetFavoritesByUserId(string userId);

    }
}
