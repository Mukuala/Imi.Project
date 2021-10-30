using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Movie:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Image { get; set; }
        public string EmbeddedTrailerUrl { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double AverageRating { get; set; }
        public IEnumerable<MovieActor> Actors { get; set; }
        public IEnumerable<MovieGenre> Genres { get; set; }
        public IEnumerable<Favorite> UsersFavorite { get; set; }
        public IEnumerable<Watchlist> UsersWatchlist { get; set; }
    }
}
