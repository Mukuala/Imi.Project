using Imi.Project.Wpf.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Imi.Project.Wpf.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
