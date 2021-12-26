using Imi.Project.Common.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class MovieRequestDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public IFormFile Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<long> ActorsId { get; set; }
        public IEnumerable<long> GenresId { get; set; }
    }
}
