using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IActionResult>GetByUserAndMovieId(string userId,long movieId)
        {
            var watchlist = await _watchlistService.GetByUserIdAndMovieId(userId,movieId);
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
