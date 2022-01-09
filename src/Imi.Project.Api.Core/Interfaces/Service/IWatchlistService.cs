using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IWatchlistService
    {
        Task<WatchlistResponseDto> GetByIdAsync(int id);
        Task<WatchlistResponseDto> GetByUserIdAndMovieId(string userId, int movieId);
        Task<WatchlistResponseDto> AddWatchlistAsync(WatchlistRequestDto watchlistRequestDto);
        Task DeleteWatchlistAsync(WatchlistRequestDto watchlistRequestDto);
        Task<IEnumerable<WatchlistResponseDto>> GetWatchlistsByUserId(string userId);
    }
}
