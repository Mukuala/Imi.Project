//using Imi.Project.Api.Core.Entities;
//using Imi.Project.Api.Core.Interfaces.Repository;
//using Imi.Project.Api.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Imi.Project.Api.Infrastructure.Repositories
//{
//    public class MovieGenreRepository: EfRepository<MovieGenre>, IRepository<MovieGenre>
//    {
//        public MovieGenreRepository(ApplicationDbContext context) : base(context)
//        {
//        }
//        public async Task<MovieGenre> GetByUserIdAndMovieId(int genreId, int movieId)
//        {
//            return await GetAllAsync().FirstOrDefaultAsync(f => f.GenreId.Equals(genreId) && f.MovieId.Equals(movieId));
//        }

//    }
//}
