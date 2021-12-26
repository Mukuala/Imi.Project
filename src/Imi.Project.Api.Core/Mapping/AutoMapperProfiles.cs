using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Imi.Project.Api.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region ApplicationUser

            CreateMap<ApplicationUser, UserResponseDto>()
                .ForMember(dest => dest.FavoritesMovies,
                 opt => opt.MapFrom(src => src.FavoriteMovies
                 .Select(f => new FavoriteResponseDto
                 {
                     MovieId = f.MovieId,
                     ApplicationUserId = f.ApplicationUserId,
                     Id = f.Id,
                     Movie = new MovieResponseDto
                     {
                         Id = f.MovieId,
                         Image = GetFullImageUrl(f.Movie.Image),
                         Name = f.Movie.Name,
                         AverageRating = f.Movie.AverageRating,
                         ReleaseDate = f.Movie.ReleaseDate,
                     }
                 }
                )))

                .ForMember(dest => dest.WatchlistMovies,
                opt => opt.MapFrom(src => src.WatchlistMovies
                  .Select(f => new WatchlistResponseDto
                  {
                      MovieId = f.MovieId,
                      ApplicationUserId = f.ApplicationUserId,
                      Id = f.MovieId,
                      Movie = new MovieResponseDto
                      {
                          Id = f.MovieId,
                          Image = GetFullImageUrl(f.Movie.Image),
                          Name = f.Movie.Name,
                          AverageRating = f.Movie.AverageRating,
                          ReleaseDate = f.Movie.ReleaseDate
                      }
                  })));

            CreateMap<UserRequestDto, ApplicationUser>();
            #endregion


            CreateMap<Favorite, FavoriteResponseDto>();

            CreateMap<FavoriteRequestDto, Favorite>();

            CreateMap<Watchlist, WatchlistResponseDto>();

            CreateMap<WatchlistRequestDto, Watchlist>();

            #region Genre
            CreateMap<Genre, GenreResponseDto>()
                .ForMember(dest => dest.Movies,
                opt => opt.MapFrom(src => src.Movies
                .Select(mg => new MovieResponseDto
                {
                    Id = mg.MovieId,
                    Name = mg.Movie.Name,
                    AverageRating = mg.Movie.AverageRating,
                    Description = mg.Movie.Description,
                    Duration = mg.Movie.Duration,
                    EmbeddedTrailerUrl = mg.Movie.EmbeddedTrailerUrl,
                    Image = GetFullImageUrl(mg.Movie.Image),
                    ReleaseDate = mg.Movie.ReleaseDate,
                })));

            CreateMap<GenreRequestDto, Genre>();
            #endregion

            #region Actor

            CreateMap<Actor, ActorResponseDto>()
                .ForMember(dest => dest.Movies,
                opt => opt.MapFrom(src => src.Movies
                 .Select(m => new MovieResponseDto
                 {
                     Id = m.MovieId,
                     Name = m.Movie.Name,
                     AverageRating = m.Movie.AverageRating,
                     Description = m.Movie.Description,
                     Duration = m.Movie.Duration,
                     EmbeddedTrailerUrl = m.Movie.EmbeddedTrailerUrl,
                     Image = GetFullImageUrl(m.Movie.Image),
                     ReleaseDate = m.Movie.ReleaseDate,
                 })));

            CreateMap<ActorRequestDto, Actor>();
            #endregion

            #region Movie
            CreateMap<Movie, MovieResponseDto>()
                .ForMember(dest => dest.Actors,
                opt => opt.MapFrom(src => src.Actors
                .Select(a => new ActorResponseDto
                {
                    Id = a.ActorId,
                    Biography = a.Actor.Biography,
                    DateOfBirth = a.Actor.DateOfBirth,
                    Image = GetFullImageUrl(a.Actor.Image),
                    Name = a.Actor.Name,
                })))

                .ForMember(dest => dest.Genres,
                opt => opt.MapFrom(src => src.Genres
                  .Select(g => new GenreResponseDto
                  {
                      Name = g.Genre.Name,
                      Id = g.Genre.Id
                  })));

            CreateMap<MovieRequestDto, Movie>();
            #endregion

        }
        string GetFullImageUrl(string image)
        {
            if (string.IsNullOrEmpty(image))
            {
                return null;
            }

            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            var scheme = httpContextAccessor.HttpContext.Request.Scheme; // example: https or http
            var url = httpContextAccessor.HttpContext.Request.Host.Value; // example: localhost:5001, howest.be, steam.com, localhost:44785, ...

            var fullImageUrl = $"{scheme}://{url}/{image}";

            return fullImageUrl;
        }


    }
}
