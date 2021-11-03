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
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByUserAndMovieId(string userId, long movieId)
        {
            var watchlist = await _favoriteService.GetByUserIdAndMovieId(userId, movieId);
            if (watchlist == null)
            {
                return NotFound();
            }

            return Ok(watchlist);

        }



        [HttpPost]
        public async Task<IActionResult> Post(FavoriteRequestDto favoriteRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var favoriteResponseDto = await _favoriteService.AddFavoriteAsync(favoriteRequestDto);
            return Ok(favoriteResponseDto);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(FavoriteRequestDto favoriteRequest)
        {
            await _favoriteService.DeleteFavoriteAsync(favoriteRequest);
            return Ok();
        }
    }
}
