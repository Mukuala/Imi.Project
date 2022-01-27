using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class GenreRepository:EfRepository<Genre>
    {
        public GenreRepository(ApplicationDbContext context): base(context)
        {
        }
        public override IQueryable<Genre> GetAllAsync()
        {
            return _dbContext.Genres
                .Include(g => g.Movies).ThenInclude(mg => mg.Movie).OrderBy(g => g.Name);
        }

    }
}
