using Imi.Project.Mobile.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IMovieService : IServiceCrudBase<Movie>
    {
        Task<ICollection<Movie>> SearchByNameAsync(string name);
        Task<ICollection<Movie>> GetMoviesByGenreIdAsync(long genreId);
        Task<ICollection<Movie>> GetMoviesByActorIdAsync(long actorId);
    }
}
