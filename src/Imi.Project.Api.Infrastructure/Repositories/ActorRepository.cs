using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class ActorRepository : EfRepository<Actor>, IActorRepository
    {
        public ActorRepository(ApplicationDbContext context) : base(context)
        {
        }
        public override IQueryable<Actor> GetAllAsync()
        {
            var entities = _dbContext.Actors.Include(a => a.Movies).ThenInclude(ma => ma.Movie);
            return entities;
        }

        public async Task<IEnumerable<Actor>> SearchByNameAsync(string name)
        {
            return await GetAllAsync().Where(a => a.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();
        }

    }
}
