using Imi.Project.Api.Core.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class MovieRequestDto: BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public IFormFile Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<ActorResponseDto> Actors { get; set; }
        public IEnumerable<GenreResponseDto> Genres { get; set; }
        public IEnumerable<UserResponseDto> FavoriteMovies { get; set; }
        public IEnumerable<UserResponseDto> Watchlist { get; set; }
    }
}
