using Imi.Project.Api.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Service
{
    public interface IWatchlistService
    {
        Task<WatchlistResponseDto> GetByIdAsync(long id);
        Task<WatchlistResponseDto> GetByUserIdAndMovieId(string userId,long movieId);
        Task<WatchlistResponseDto> AddWatchlistAsync(WatchlistRequestDto watchlistRequestDto);
        Task DeleteWatchlistAsync(WatchlistRequestDto watchlistRequestDto);
        Task<IEnumerable<WatchlistResponseDto>> GetWatchlistsByUserId(string userId);
    }
}
