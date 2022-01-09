using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IWatchlistRepository : IRepository<Watchlist>
    {
        Task<Watchlist> GetByUserIdAndMovieIdAsync(string userId, int movieId);
        Task<Watchlist> AddByUserIdAndMovieIdAsync(string userId, int movieId);
        Task<IEnumerable<Watchlist>> GetWatchlistsByUserIdAsync(string userId);
    }
}
