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
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override IQueryable<Movie> GetAllAsync()
        {
            return _dbContext.Movies
            .Include(m => m.Actors).ThenInclude(ma => ma.Actor)
            .Include(m => m.Genres).ThenInclude(mg => mg.Genre)
            .Include(m => m.UsersFavorite).ThenInclude(f => f.ApplicationUser)
            .Include(m => m.UsersWatchlist).ThenInclude(w => w.ApplicationUser);
        }
        public async Task<IEnumerable<Movie>> GetByActorId(long id)
        {
            return await GetAllAsync()
                .Where(m => m.Actors.Any(ma => ma.ActorId.Equals(id))).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetByGenreId(long id)
        {
            return await GetAllAsync()
                .Where(m => m.Genres.Any(mg => mg.GenreId.Equals(id))).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchByNameAsync(string name)
        {
               return await GetAllAsync()
                .Where(g => g.Name.ToUpper().Contains(name.ToUpper()))
                .ToListAsync();
        }
    }
}
