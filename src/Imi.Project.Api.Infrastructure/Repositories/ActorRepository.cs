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
            var entities = _dbContext.Actors.Include(a => a.Movies).ThenInclude(ma => ma.Movie).OrderBy(a => a.Name);
            return entities;
        }
        public override async Task<Actor> GetByIdAsync(int id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(a => a.Id.Equals(id));
        }
        public async Task<IEnumerable<Actor>> SearchByNameAsync(string name)
        {
            return await GetAllAsync().Where(a => a.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();
        }
        public override async Task<Actor> UpdateAsync(Actor actor)
        {
            var oldActor = await GetByIdAsync(actor.Id);

            //Savechanges when image/actor has been changed in imageservice
            if (oldActor == actor)
            {
                await _dbContext.SaveChangesAsync();
                return oldActor;
            }

            oldActor.DateOfBirth = actor.DateOfBirth;
            oldActor.Name = actor.Name;
            oldActor.Id = actor.Id;
            oldActor.Movies = actor.Movies;

            _dbContext.Actors.Update(oldActor);
            await _dbContext.SaveChangesAsync();

            return actor;
        }

    }
}
