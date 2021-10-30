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
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
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
        [HttpGet("{id}/actors")]
        public async Task<IActionResult>GetByActorId(long id)
        {
            var movies = await _movieService.GetMoviesByActorId(id);
            if (!movies.Any())
            {
                return NotFound($"There were no movies found with actor id {id}");
            }
            return Ok(movies);

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
