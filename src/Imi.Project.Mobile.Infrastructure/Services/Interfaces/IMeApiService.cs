using Imi.Project.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IMeApiService
    {
        Task<IEnumerable<MovieResponseDto>> GetFavoritesMovies(string jwtToken);
        Task AddToFavorite(string jwtToken, int movieId);
        Task DeleteFavorite(string jwtToken, int movieId);
        Task<IEnumerable<MovieResponseDto>> GetWatchlistMovies(string jwtToken);
        Task AddToWatchlist(string jwtToken, int movieId);
        Task DeleteWatchlist(string jwtToken, int movieId);
        Task<UserResponseDto> GetJwtUserProfile(string jwtToken);
        Task EditProfile(UserRequestDto user, string jwtToken);
        Task PostImageAsync(byte[] imgByteArray, string imgName, string id, string jwtToken);

    }
}
