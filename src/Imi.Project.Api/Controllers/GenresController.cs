using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Api.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imi.Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IService<GenreResponseDto,GenreRequestDto> _genreService;

        public GenresController(IService<GenreResponseDto,GenreRequestDto> genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var genres = await _genreService.ListAllAsync();
            return Ok(genres);
        }
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
