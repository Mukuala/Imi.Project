using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IHttpContextAccessor _contextAccessor;


        public FavoritesController(IFavoriteService favoriteService, IHttpContextAccessor contextAccessor)
        {
            _favoriteService = favoriteService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoggedInUserFavorites()
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            var favorites = await _favoriteService.GetFavoritesByUserId(userId);
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
            var favoriteResponseDto = await _favoriteService.AddFavoriteAsync(userId,movieId);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int movieId)
        {
            var userId = User.Identities.FirstOrDefault().FindFirst(ClaimTypes.NameIdentifier).Value;
            await _favoriteService.DeleteFavoriteAsync(userId, movieId);
            return Ok();
        }
    }
}
