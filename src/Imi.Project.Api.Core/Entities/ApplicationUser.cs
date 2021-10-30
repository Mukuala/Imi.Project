using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace Imi.Project.Api.Core.Entities
{
    public class ApplicationUser
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Favorite> FavoriteMovies { get; set; }
        public IEnumerable<Watchlist> WatchlistMovies { get; set; } 
    }
}
