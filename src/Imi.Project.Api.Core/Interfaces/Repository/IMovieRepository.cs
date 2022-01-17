using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IMovieRepository:IRepository<Movie>
    {
        Task<IEnumerable<Movie>> SearchByNameAsync(string name);
        Task<IEnumerable<Movie>> GetByActorId(int id);
        Task<IEnumerable<Movie>> GetByGenreId(int id);
    }
}
