using Imi.Project.Common.Dtos.Base;
using System;
using System.Collections.Generic;
namespace Imi.Project.Common.Dtos
{
    public class UserResponseDto : BaseDto<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public string Role { get; set; }
        public ICollection<MovieResponseDto> FavoritesMovies { get; set; }
        public ICollection<MovieResponseDto> WatchlistMovies { get; set; }
    }
}
