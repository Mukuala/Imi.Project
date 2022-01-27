using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Imi.Project.Api.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region ApplicationUser

            CreateMap<ApplicationUser, UserResponseDto>()
                .ForMember(u => u.Image, opt => opt.MapFrom(src => GetFullImageUrl(src.Image)))
                .ForMember(dest => dest.FavoritesMovies,
                 opt => opt.MapFrom(src => src.FavoriteMovies
                 .Select(f => new MovieResponseDto
                 {
                     //MovieId = f.MovieId,
                     //ApplicationUserId = f.ApplicationUserId,
                     //Movie = new MovieResponseDto
                     //{
                         Id = f.MovieId,
                         Image = GetFullImageUrl(f.Movie.Image),
                         Name = f.Movie.Name,
                         AverageRating = f.Movie.AverageRating,
                         ReleaseDate = f.Movie.ReleaseDate,
                     //}
                 }
                )))

                .ForMember(dest => dest.WatchlistMovies,
                opt => opt.MapFrom(src => src.WatchlistMovies
                  .Select(f => new MovieResponseDto
                  {
                      //MovieId = f.MovieId,
                      //ApplicationUserId = f.ApplicationUserId,
                      //Movie = new MovieResponseDto
                      //{
                          Id = f.MovieId,
                          Image = GetFullImageUrl(f.Movie.Image),
                          Name = f.Movie.Name,
                          AverageRating = f.Movie.AverageRating,
                          ReleaseDate = f.Movie.ReleaseDate
                      //}
                  })));

            CreateMap<UserRequestDto, ApplicationUser>()
                .ForMember(au => au.NormalizedEmail, opt => opt.MapFrom(ur => ur.Email.ToUpper()))
                .ForMember(au => au.NormalizedUserName, opt => opt.MapFrom(ur => ur.UserName.ToUpper()));
            #endregion


            CreateMap<Favorite, FavoriteResponseDto>();

            CreateMap<FavoriteRequestDto, Favorite>();

            CreateMap<Watchlist, WatchlistResponseDto>();

            CreateMap<WatchlistRequestDto, Watchlist>();

            #region Genre
            CreateMap<Genre, GenreResponseDto>();
                //.ForMember(dest => dest.Movies,
                //opt => opt.MapFrom(src => src.Movies
                //.Select(mg => new MovieResponseDto
                //{
                //    Id = mg.MovieId,
                //    Name = mg.Movie.Name,
                //    AverageRating = mg.Movie.AverageRating,
                //    Description = mg.Movie.Description,
                //    Duration = mg.Movie.Duration,
                //    EmbeddedTrailerUrl = mg.Movie.EmbeddedTrailerUrl,
                //    Image = GetFullImageUrl(mg.Movie.Image),
                //    ReleaseDate = mg.Movie.ReleaseDate,
                //})));

            CreateMap<GenreRequestDto, Genre>();
            #endregion

            #region Actor

            CreateMap<Actor, ActorResponseDto>()
                .ForMember(a => a.Image, opt => opt.MapFrom(src => GetFullImageUrl(src.Image)))
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
                .ForMember(d => d.Image, opt => opt.MapFrom(src=> GetFullImageUrl(src.Image)))
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

            CreateMap<MovieRequestDto, Movie>()
                .ForMember(dest=>dest.Actors,
                opt => opt.MapFrom(src => src.ActorsId
                .Select(a => new MovieActor
                {
                    ActorId = a,
                    MovieId = src.Id
                })))

                .ForMember(dest=>dest.Genres,
                opt => opt.MapFrom(src => src.GenresId
                .Select(g => new MovieGenre
                {
                    GenreId = g,
                    MovieId = src.Id
                })));
            #endregion

        }
        string GetFullImageUrl(string image)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();

            if (string.IsNullOrEmpty(image))
            {
                var scheme = httpContextAccessor.HttpContext.Request.Scheme; // example: https or http
                var url = httpContextAccessor.HttpContext.Request.Host.Value; // example: localhost:5001, howest.be, steam.com, localhost:44785, ...
                var noImageimgUrl = $"{scheme}://{url}/Images/No_Image.png";

                return noImageimgUrl;
            }
            else
            {
                if (image.Contains("https://robohash.org/"))
                {
                    return image;
                }
                var scheme = httpContextAccessor.HttpContext.Request.Scheme; // example: https or http
                var url = httpContextAccessor.HttpContext.Request.Host.Value; // example: localhost:5001, howest.be, steam.com, localhost:44785, ...

                var fullImageUrl = $"{scheme}://{url}/{image}";

                return fullImageUrl;
            }
        }
    }
}
