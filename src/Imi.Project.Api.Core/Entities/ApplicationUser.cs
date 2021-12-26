using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public DateTime Birthday { get; set; }
        public IEnumerable<Favorite> FavoriteMovies { get; set; }
        public IEnumerable<Watchlist> WatchlistMovies { get; set; }
    }
}
