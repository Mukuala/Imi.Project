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
    public class ActorsController : ControllerBase
    {
        private readonly IActorService _actorService;
        private readonly IMovieService _movieService;


        public ActorsController(IActorService actorService, IMovieService movieService)
        {
            _actorService = actorService;
            _movieService = movieService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string name)
        {
            if (name != null)
            {
                var actors = await _actorService.SearchByNameAsync(name);
                if (actors.Any())
                {
                    return Ok(actors);
                }
                return NotFound($"There were no actors found that contain {name} in their name");
            }
            else
            {
                var actors = await _actorService.ListAllAsync();

                return Ok(actors);
            }

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound($"Actor with ID {id} does not exist");
            }

            return Ok(actor);
        }
        [AllowAnonymous]
        [HttpGet("{id}/movies")]
        public async Task<IActionResult> GetMoviesByActorId(int id)
        {
            var movies = await _movieService.GetMoviesByActorId(id);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ActorRequestDto actorRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actorResponseDto = await _actorService.AddAsync(actorRequestDto);
            return CreatedAtAction(nameof(Get), new { id = actorResponseDto.Id }, actorResponseDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ActorRequestDto actorRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actorResponseDto = await _actorService.UpdateAsync(actorRequestDto);
            return Ok(actorResponseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var actor = await _actorService.GetByIdAsync(id);
            if (actor == null)
            {
                return NotFound($"Actor with ID {id} does not exist");
            }

            await _actorService.DeleteAsync(id);
            return Ok();
        }
    }
}
