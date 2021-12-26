using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize(Policy = "CanDoCrud")]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IActorService _actorService;

        public MoviesController(IMovieService movieService, IActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            if (name != null)
            {
                var movies = await _movieService.SearchByNameAsync(name);
                if (movies.Any())
                {
                    return Ok(movies);
                }
                return NotFound($"There were no movies found that contain {name} in their name");
            }
            else
            {
                var movies = await _movieService.ListAllAsync();

                return Ok(movies);
            }

        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} does not exist");
            }

            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> Post(MovieRequestDto movieRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameResponseDto = await _movieService.AddAsync(movieRequestDto);
            return CreatedAtAction(nameof(Get), new { id = gameResponseDto.Id }, gameResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(MovieRequestDto movieRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameResponseDto = await _movieService.UpdateAsync(movieRequestDto);
            return Ok(gameResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} does not exist");
            }

            await _movieService.DeleteAsync(id);
            return Ok();
        }

    }
}
