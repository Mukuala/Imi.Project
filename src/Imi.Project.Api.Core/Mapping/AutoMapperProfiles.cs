using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                     Id = f.MovieId,
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
                    //Genres = mg.Movie.Genres.Select(m => new GenreResponseDto
                    //{
                    //    Name = m.Genre.Name,
                    //    Id = m.Genre.Id
                    //}),
                    //Actors = mg.Movie.Actors.Select(ma => new ActorResponseDto
                    //{
                    //    Name = ma.Actor.Name,
                    //    Id = ma.Actor.Id,
                    //    //Biography = ma.Actor.Biography,
                    //    //DateOfBirth = ma.Actor.DateOfBirth,
                    //    //Image = 
                    //})
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
                     //Genres = m.Movie.Genres.Select(mg => new GenreResponseDto
                     //{
                     //    Name = mg.Genre.Name,
                     //    Id = mg.Genre.Id
                     //}),
                     //Actors = m.Movie.Actors.Select(ma => new ActorResponseDto
                     //{
                     //    Name = ma.Actor.Name,
                     //    Id = ma.Actor.Id,
                     //    //Biography = ma.Actor.Biography,
                     //    //DateOfBirth = ma.Actor.DateOfBirth,
                     //    //Image = 
                     //})
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
                    //Movies = a.Actor.Movies.Select(m => new MovieResponseDto
                    //{

                    //    Id = m.MovieId,
                    //    Name = m.Movie.Name,
                    //    AverageRating = m.Movie.AverageRating,
                    //    Description = m.Movie.Description,
                    //    Duration = m.Movie.Duration,
                    //    EmbeddedTrailerUrl = m.Movie.EmbeddedTrailerUrl,
                    //    Image = m.Movie.Image,
                    //    ReleaseDate = m.Movie.ReleaseDate,
                    //    Genres = m.Movie.Genres.Select(mg => new GenreResponseDto
                    //    {
                    //        Name = mg.Genre.Name,
                    //        Id = mg.Genre.Id
                    //    }),
                    //    Actors = m.Movie.Actors.Select(ma => new ActorResponseDto
                    //    {
                    //        Name = ma.Actor.Name,
                    //        Id = ma.Actor.Id,
                    //        //Biography = ma.Actor.Biography,
                    //        //DateOfBirth = ma.Actor.DateOfBirth,
                    //        //Image = 
                    //    })
                    //})
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
