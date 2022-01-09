using Imi.Project.Api.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        Task<Favorite> GetByUserIdAndMovieIdAsync(string userId, int movieId);
        Task<Favorite> AddByUserIdAndMovieIdAsync(string userId, int movieId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserIdAsync(string userId);
    }
}
