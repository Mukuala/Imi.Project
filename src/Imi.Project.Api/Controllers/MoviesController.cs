using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        private readonly IImageService _imageService;

        public MoviesController(IMovieService movieService, IActorService actorService, IImageService imageService)
        {
            _movieService = movieService;
            _actorService = actorService;
            _imageService = imageService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
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
        public async Task<IActionResult> Get(int id)
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
            var movieResponseDto = await _movieService.AddAsync(movieRequestDto);

            return CreatedAtAction(nameof(Get), new { id = movieResponseDto.Id }, movieResponseDto);
        }
        [HttpPut]
        public async Task<IActionResult> Put(MovieRequestDto movieRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieResponseDto = await _movieService.UpdateAsync(movieRequestDto);
            return Ok(movieResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null)
            {
                return NotFound($"Movie with ID {id} does not exist");
            }

            await _movieService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> AddOrUpdateImage(int id, IFormFile image)
        {
            if (image == null)
            {
                return Ok("No image has been added");
            }
            var movie = await _movieService.GetByIdAsync(id);

            if (movie == null)
            {
                return BadRequest("Movie doesn't exists!");
            }
            await _imageService.AddOrUpdateImageAsync<MovieRequestDto>(image, id.ToString(), false);
            return Ok();
        }

    }
}
