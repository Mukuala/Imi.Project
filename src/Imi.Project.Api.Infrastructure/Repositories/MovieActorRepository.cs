using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class MovieActorRepository : EfRepository<MovieActor>, IRepository<MovieActor>
    {
        public MovieActorRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<MovieActor> GetByUserIdAndMovieId(long actorId, long movieId)
        {
            return await GetAllAsync().FirstOrDefaultAsync(f => f.ActorId.Equals(actorId) && f.MovieId.Equals(movieId));
        }

    }
}
