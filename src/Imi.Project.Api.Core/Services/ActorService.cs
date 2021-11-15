using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepo;
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public ActorService(IActorRepository actorRepo, IMapper mapper, IImageService imageService, IMovieRepository movieRepo)
        {
            _actorRepo = actorRepo;
            _mapper = mapper;
            _imageService = imageService;
            _movieRepo = movieRepo;
        }

        public async Task<ActorResponseDto> AddAsync(ActorRequestDto RequestDto)
        {
            var entity = _mapper.Map<Actor>(RequestDto);
            entity.Image = await _imageService.AddOrUpdateImageAsync<Actor>(null, entity, null, RequestDto.Image);
            var result = await _actorRepo.AddAsync(entity);
            var dto = _mapper.Map<ActorResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(long id)
        {
            await _actorRepo.DeleteAsync(id);
        }

        public async Task<ActorResponseDto> GetByIdAsync(long id)
        {
            var result = await _actorRepo.GetByIdAsync(id);
            var dto = _mapper.Map<ActorResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<ActorResponseDto>> ListAllAsync()
        {
            var result = await _actorRepo.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<ActorResponseDto>>(result);
            return dto;
        }


        public async Task<IEnumerable<ActorResponseDto>> SearchByNameAsync(string name)
        {
            var users = await _actorRepo.SearchByNameAsync(name);
            var dto = _mapper.Map<IEnumerable<ActorResponseDto>>(users);
            return dto;
        }

        public async Task<ActorResponseDto> UpdateAsync(ActorRequestDto RequestDto)
        {
            var entity = _mapper.Map<Actor>(RequestDto);
            if (RequestDto.Image != null)
            {
                entity.Image = await _imageService.AddOrUpdateImageAsync<Actor>(null, entity, null, RequestDto.Image);
            }
            else
                entity.Image = _actorRepo.GetByIdAsync(RequestDto.Id.Value).Result.Image;
            var result = await _actorRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);
        }
    }
}

