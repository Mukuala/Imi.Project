using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepo, IMapper mapper, IImageService imageService)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<MovieResponseDto> AddAsync(MovieRequestDto RequestDto)
        {
            var entity = _mapper.Map<Movie>(RequestDto);
            //entity.Image = await _imageService.AddOrUpdateImageAsync<MovieRequestDto>(RequestDto.Image, RequestDto.Id.ToString(),false);
            var x = await _movieRepo.AddAsync(entity);
            var result = await _movieRepo.GetByIdAsync(x.Id);
            var dto = _mapper.Map<MovieResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await _imageService.AddOrUpdateImageAsync<MovieRequestDto>(null, id.ToString(), true);
            await _movieRepo.DeleteAsync(id);
        }

        public async Task<MovieResponseDto> GetByIdAsync(int id)
        {
            var result = await _movieRepo.GetByIdAsync(id);
            var dto = _mapper.Map<MovieResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<MovieResponseDto>> GetMoviesByActorId(int id)
        {
            var result = await _movieRepo.GetByActorId(id);
            var dto = _mapper.Map<IEnumerable<MovieResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<MovieResponseDto>> GetMoviesByGenreId(int id)
        {
            var result = await _movieRepo.GetByGenreId(id);
            var dto = _mapper.Map<IEnumerable<MovieResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<MovieResponseDto>> ListAllAsync()
        {
            var result = await _movieRepo.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<MovieResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<MovieResponseDto>> SearchByNameAsync(string userName)
        {
            var users = await _movieRepo.SearchByNameAsync(userName);
            var dto = _mapper.Map<IEnumerable<MovieResponseDto>>(users);
            return dto;
        }

        public async Task<MovieResponseDto> UpdateAsync(MovieRequestDto RequestDto)
        {
            var entity = _mapper.Map<Movie>(RequestDto);
            //entity.Image = await _imageService.AddOrUpdateImageAsync<MovieRequestDto>(RequestDto.Image, RequestDto.Id.ToString(), false);
            var result = await _movieRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);
        }
    }
}
