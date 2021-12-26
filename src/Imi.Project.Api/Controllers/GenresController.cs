using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Authorize(Policy = "CanDoCrud")]
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IService<GenreResponseDto, GenreRequestDto> _genreService;
        private readonly IMovieService _movieService;

        public GenresController(IService<GenreResponseDto, GenreRequestDto> genreService, IMovieService movieService)
        {
            _genreService = genreService;
            _movieService = movieService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreService.ListAllAsync();
            return Ok(genres);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {

            var genre = await _genreService.GetByIdAsync(id);

            if (genre == null)
            {
                return NotFound($"Genre with ID {id} does not exist");
            }
            return Ok(genre);
        }

        [HttpGet("{id}/movies")]
        public async Task<IActionResult> GetMoviesByGenreId(long id)
        {
            var movies = await _movieService.GetMoviesByGenreId(id);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GenreRequestDto genreRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genreResponseDto = await _genreService.AddAsync(genreRequestDto);
            return CreatedAtAction(nameof(Get), new { id = genreResponseDto.Id }, genreResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(GenreRequestDto genreRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var genreResponseDto = await _genreService.UpdateAsync(genreRequestDto);
            return Ok(genreResponseDto);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var genre = await _genreService.GetByIdAsync(id);
            if (genre == null)
            {
                return NotFound($"Genre with ID {id} does not exist");
            }

            await _genreService.DeleteAsync(id);
            return Ok();
        }
    }
}
