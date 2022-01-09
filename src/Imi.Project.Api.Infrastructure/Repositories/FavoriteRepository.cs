using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class FavoriteRepository : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Favorite> GetByUserIdAndMovieIdAsync(string userId, int movieId)
        {
            return await GetAllAsync().FirstOrDefaultAsync(f => f.ApplicationUserId.Equals(userId) && f.MovieId.Equals(movieId));
        }
        public async Task<Favorite> AddByUserIdAndMovieIdAsync(string userId, int movieId)
        {
            var entity = new Favorite { ApplicationUserId = userId, MovieId = movieId };
            return await AddAsync(entity);
        }
        public async Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(string userId)
        {
            return await GetAllAsync().Where(w => w.ApplicationUserId.Equals(userId)).ToListAsync();
        }

    }
}
