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
            var entities = _dbContext.Movies
            .Include(m => m.Actors).ThenInclude(ma => ma.Actor)
            .Include(m => m.Genres).ThenInclude(mg => mg.Genre)
            .Include(m => m.UsersFavorite).ThenInclude(f => f.ApplicationUser)
            .Include(m => m.UsersWatchlist).ThenInclude(w => w.ApplicationUser);

            return entities;
        }
        public async override Task<Movie> GetByIdAsync(int id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(m => m.Id.Equals(id));
        }
        public async Task<IEnumerable<Movie>> GetByActorId(int actorId)
        {
            return await GetAllAsync()
                .Where(m => m.Actors.Any(ma => ma.ActorId.Equals(actorId))).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetByGenreId(int genreId)
        {
            return await GetAllAsync()
                .Where(m => m.Genres.Any(mg => mg.GenreId.Equals(genreId))).ToListAsync();
        }

        public async Task<IEnumerable<Movie>> SearchByNameAsync(string name)
        {
            return await GetAllAsync()
             .Where(g => g.Name.ToUpper().Contains(name.ToUpper()))
             .ToListAsync();
        }
        public override async Task<Movie> UpdateAsync(Movie movie)
        {
            var oldMovie = await GetByIdAsync(movie.Id);

            if (oldMovie == movie)
            {
                await _dbContext.SaveChangesAsync();
                return oldMovie;
            }
            _dbContext.MovieActors.RemoveRange(oldMovie.Actors);
            _dbContext.MovieGenres.RemoveRange(oldMovie.Genres);
            if (movie.Actors.Count() > 0)
            {
                foreach (var item in movie.Actors)
                {
                    _dbContext.MovieActors.Add(new MovieActor
                    {
                        MovieId = item.MovieId,
                        ActorId = item.ActorId
                    });
                }

            }
            if (movie.Genres.Count() > 0)
            {
                foreach (var item in movie.Genres)
                {
                    _dbContext.MovieGenres.Add(new MovieGenre
                    {
                        MovieId = item.MovieId,
                        GenreId = item.GenreId
                    });
                }
            }
            oldMovie.Image = movie.Image;
            oldMovie.Name = movie.Name;
            oldMovie.ReleaseDate = movie.ReleaseDate;
            oldMovie.UsersFavorite = movie.UsersFavorite;
            oldMovie.UsersWatchlist = movie.UsersWatchlist;
            oldMovie.AverageRating = movie.AverageRating;
            oldMovie.Duration = movie.Duration;
            oldMovie.Description = movie.Description;
            oldMovie.EmbeddedTrailerUrl = movie.EmbeddedTrailerUrl;

            _dbContext.Movies.Update(oldMovie);
            await _dbContext.SaveChangesAsync();

            var newUpdatedMovie = await GetByIdAsync(movie.Id);
            return newUpdatedMovie;

        }
    }
}
