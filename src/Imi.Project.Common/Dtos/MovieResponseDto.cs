using Imi.Project.Common.Dtos.Base;
using System;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class MovieResponseDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<ActorResponseDto> Actors { get; set; }
        public IEnumerable<GenreResponseDto> Genres { get; set; }
    }
}
