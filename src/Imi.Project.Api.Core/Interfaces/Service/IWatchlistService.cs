using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IWatchlistService
    {
        Task<WatchlistResponseDto> GetByUserIdAndMovieId(string userId, int movieId);
        Task<WatchlistResponseDto> AddWatchlistAsync(string userId,int movieId);
        Task DeleteWatchlistAsync(string userId, int movieId);
        Task<IEnumerable<WatchlistResponseDto>> GetWatchlistsByUserId(string userId);
    }
}
