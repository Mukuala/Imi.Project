using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class WatchlistRepository : EfRepository<Watchlist>, IWatchlistRepository
    {
        public WatchlistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Watchlist> AddByUserIdAndMovieIdAsync(string userId, int movieId)
        {
            var entity = new Watchlist { ApplicationUserId = userId, MovieId = movieId };
            return await AddAsync(entity);
        }

        public async Task<Watchlist> GetByUserIdAndMovieIdAsync(string userId, int movieId)
        {
            return await GetAllAsync().FirstOrDefaultAsync(f => f.ApplicationUserId.Equals(userId) && f.MovieId.Equals(movieId));
        }
        public async Task<IEnumerable<Watchlist>> GetWatchlistsByUserIdAsync(string userId)
        {
            return await GetAllAsync().Where(w => w.ApplicationUserId.Equals(userId)).ToListAsync();
        }

    }
}
