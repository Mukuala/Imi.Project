using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Api.Core.Services.User;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IUserService _userService;
        private readonly IImageService _imageService;

        public MeController(IMeService meService, IFavoriteService favoriteService, IWatchlistService watchlistService, IUserService userService, IImageService imageService)
        {
            _meService = meService; 
            _favoriteService = favoriteService;
            _watchlistService = watchlistService;
            _userService = userService;
            _imageService = imageService;
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var profile = await _meService.GetCurrentUserProfileAsync();
            return Ok(profile);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userResponseDto = await _userService.UpdateAsync(userRequestDto);
            return Ok(userResponseDto);
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
        public async Task<IActionResult> PostFavorite([FromBody]int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _favoriteService.AddFavoriteAsync(userId, movieId);
            return Ok();
        }

        [HttpDelete("favorites/{movieId}")]
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
        public async Task<IActionResult> Post([FromBody]int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _watchlistService.AddWatchlistAsync(userId, movieId);
            return Ok();
        }

        [HttpDelete("watchlists/{movieId}")]
        public async Task<IActionResult> Delete(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            await _watchlistService.DeleteWatchlistAsync(userId, movieId);
            return Ok();
        }

        #endregion

        [HttpPost("{id}/image")]
        public async Task<IActionResult> AddOrUpdateImage(string id, IFormFile image)
        {
            if (image == null)
            {
                return Ok("No image has been added");
            }
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return BadRequest("User doesn't exist!");
            }
            await _imageService.AddOrUpdateImageAsync<UserRequestDto>(image, id, false);
            return Ok();
        }


    }
}
