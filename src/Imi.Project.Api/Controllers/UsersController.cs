using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize(Policy = "CanAccessUsers")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWatchlistService _watchlistService;
        private readonly IFavoriteService _favoriteService;


        public UsersController(IUserService userService, IWatchlistService watchlistService, IFavoriteService favoriteService)
        {
            _userService = userService;
            _favoriteService = favoriteService;
            _watchlistService = watchlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string userName)
        {
            if (userName != null)
            {
                var users = await _userService.SearchByUserNameAsync(userName);
                if (users.Any())
                {
                    return Ok(users);
                }
                return NotFound($"There were no users found that contain {userName} in their name");
            }
            else
            {
                var users = await _userService.ListAllAsync();

                return Ok(users);
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} does not exist");
            }

            return Ok(user);
        }

        [HttpGet("{id}/favorites")]
        public async Task<IActionResult> GetFavoritesByUserId(string id)
        {
            var favorites = await _favoriteService.GetFavoritesByUserId(id);
            var movies = favorites.Select(w => w.Movie);
            return Ok(movies);
        }

        [HttpGet("{id}/watchlists")]
        public async Task<IActionResult> GetWatchlistsByUserId(string id)
        {
            var watchlists = await _watchlistService.GetWatchlistsByUserId(id);
            var movies = watchlists.Select(w => w.Movie);
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserRequestDto userRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userResponseDto = await _userService.AddAsync(userRequestDto);
            return CreatedAtAction(nameof(Get), new { id = userResponseDto.Id }, userResponseDto);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} does not exist");
            }

            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
