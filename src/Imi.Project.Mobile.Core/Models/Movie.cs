using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Movie : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public ICollection<Actor> Actors { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}
