using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Movie> FavoritesMovies { get; set; }
        public IEnumerable<Movie> WatchlistMovies { get; set; }
    }
}
