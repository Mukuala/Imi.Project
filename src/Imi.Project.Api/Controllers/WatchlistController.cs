using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("id")]
        public async Task<IActionResult> GetByUserAndMovieId(string userId, int movieId)
        {
            var watchlist = await _watchlistService.GetByUserIdAndMovieId(userId, movieId);
            if (watchlist == null)
            {
                return NotFound();
            }

            return Ok(watchlist);

        }

        [HttpPost]
        public async Task<IActionResult> Post(WatchlistRequestDto watchlistRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var watchlistResponseDto = await _watchlistService.AddWatchlistAsync(watchlistRequestDto);
            return Ok(watchlistResponseDto);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(WatchlistRequestDto watchlistRequest)
        {
            await _watchlistService.DeleteWatchlistAsync(watchlistRequest);
            return Ok();
        }
    }
}
