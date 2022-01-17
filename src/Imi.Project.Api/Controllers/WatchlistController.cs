using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLoggedInUserWatchlists()
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            var favorites = await _watchlistService.GetWatchlistsByUserId(userId);
            if (favorites == null)
            {
                return NotFound();
            }
            return Ok(favorites);
        }
        [HttpPost]
        public async Task<IActionResult> Post(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var watchlistResponseDto = await _watchlistService.AddWatchlistAsync(userId, movieId);
            return Ok(watchlistResponseDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            await _watchlistService.DeleteWatchlistAsync(userId, movieId);
            return Ok();
        }
    }
}
