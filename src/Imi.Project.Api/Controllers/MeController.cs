using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Api.Core.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class MeController : ControllerBase
    {
        private readonly IMeService _meService;
        private readonly IFavoriteService _favoriteService;
        private readonly IWatchlistService _watchlistService;
        public MeController(IMeService meService, IFavoriteService favoriteService, IWatchlistService watchlistService)
        {
            _meService = meService; 
            _favoriteService = favoriteService;
            _watchlistService = watchlistService;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var profile = await _meService.GetCurrentUserProfileAsync();
            return Ok(profile);
        }
        #region Favorites
        [HttpGet("favorites")]
        public async Task<IActionResult> GetLoggedInUserFavoriteMovies()
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            var favorites = await _favoriteService.GetFavoritesByUserId(userId);
            if (favorites == null)
            {
                return NotFound();
            }
            var favMovies = favorites.Select(f => f.Movie);

            return Ok(favMovies);
        }
        [HttpPost("favorites")]
        public async Task<IActionResult> PostFavorite(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _favoriteService.AddFavoriteAsync(userId, movieId);
            return Ok();
        }

        [HttpDelete("favorites")]
        public async Task<IActionResult> DeleteFavorite(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            await _favoriteService.DeleteFavoriteAsync(userId, movieId);
            return Ok();
        }

        #endregion

        #region Watchlists
        [HttpGet("watchlists")]
        public async Task<IActionResult> GetLoggedInUserWatchlists()
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            var watchlists = await _watchlistService.GetWatchlistsByUserId(userId);
            if (watchlists == null)
            {
                return NotFound();
            }
            var watchlistMovies = watchlists.Select(f => f.Movie);
            return Ok(watchlistMovies);
        }
        [HttpPost("watchlists")]
        public async Task<IActionResult> Post(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _watchlistService.AddWatchlistAsync(userId, movieId);
            return Ok();
        }

        [HttpDelete("watchlists")]
        public async Task<IActionResult> Delete(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            await _watchlistService.DeleteWatchlistAsync(userId, movieId);
            return Ok();
        }

        #endregion

    }
}
