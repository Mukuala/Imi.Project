using Imi.Project.Mobile.Core.Models;
using Imi.Project.Mobile.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services
{
    public class ApiMovieService : ServiceCrudBase<Movie>, IMovieService
    {
        public async Task<ICollection<Movie>> GetMoviesByActorIdAsync(int actorId)
        {
            return await WebApiClient.GetApiResult<ICollection<Movie>>($"{baseApiUri}{nameof(Actor)}s/{actorId}/{nameof(Movie).ToLower()}s");
        }

        public async Task<ICollection<Movie>> GetMoviesByGenreIdAsync(int genreId)
        {
            return await WebApiClient.GetApiResult<ICollection<Movie>>($"{baseApiUri}{nameof(Genre)}s/{genreId}/{nameof(Movie).ToLower()}s");
        }
        public async Task<ICollection<Movie>> SearchByNameAsync(string name)
        {
            return await WebApiClient.GetApiResult<ICollection<Movie>>($"{baseApiUri}{nameof(Movie)}s?name={name}");
        }

    }
}
