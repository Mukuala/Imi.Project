using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
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
            CreateMap<ApplicationUser, UserResponseDto>()
                .ForMember(dest => dest.FavoritesMovies,
                 opt => opt.MapFrom(src => src.FavoriteMovies
                 .Select(f => new MovieResponseDto
                 {
                     Id = f.Movie.Id
                 }
                )))

                .ForMember(dest => dest.WatchlistMovies,
                opt => opt.MapFrom(src => src.WatchlistMovies
                  .Select(w => new MovieResponseDto
                  {
                      Id = w.Movie.Id
                  })));

            CreateMap<UserRequestDto, ApplicationUser>();

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
                    Image = mg.Movie.Image,
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
                     Image = m.Movie.Image,
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

            CreateMap<Movie, MovieResponseDto>()
                .ForMember(dest => dest.Actors,
                opt => opt.MapFrom(src => src.Actors
                .Select(a => new ActorResponseDto
                {
                    Id = a.ActorId,
                    Biography = a.Actor.Biography,
                    DateOfBirth = a.Actor.DateOfBirth,
                    Image = a.Actor.Image,
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

        }
    }
}
