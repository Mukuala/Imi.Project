using System;
using System.Collections.Generic;
namespace Imi.Project.Common.Dtos
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsModerator { get; set; }
        public IEnumerable<FavoriteResponseDto> FavoritesMovies { get; set; }
        public IEnumerable<WatchlistResponseDto> WatchlistMovies { get; set; }
    }
}
