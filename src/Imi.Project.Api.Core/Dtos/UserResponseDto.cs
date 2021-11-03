using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace Imi.Project.Api.Core.Dtos
{
    public class UserResponseDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public IEnumerable<FavoriteResponseDto> FavoritesMovies { get; set; }
        public IEnumerable<WatchlistResponseDto> WatchlistMovies { get; set; }
    }
}
