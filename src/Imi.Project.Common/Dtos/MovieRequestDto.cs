using Imi.Project.Common.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class MovieRequestDto : BaseDto<int>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Duration { get; set; }
        public IFormFile Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        [RegularExpression(@"^\d+.?\d{0,1}$", ErrorMessage = "Maximum one Decimal Point. Example: 7,5 not 7,50..")]
        [Range(0, 10.0,ErrorMessage ="Min 0 and max 10!")]
        public double AverageRating { get; set; }
        public IEnumerable<int> ActorsId { get; set; }
        public IEnumerable<int> GenresId { get; set; }
    }
}
