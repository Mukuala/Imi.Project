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
        private readonly IMapper _mapper;

        public ActorService(IActorRepository actorRepo, IMapper mapper)
        {
            _actorRepo = actorRepo;
            _mapper = mapper;

        }

        public async Task<ActorResponseDto> AddAsync(ActorRequestDto RequestDto)
        {
            var entity = _mapper.Map<Actor>(RequestDto);

            var result = await _actorRepo.AddAsync(entity);
            var dto = _mapper.Map<ActorResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(long id)
        {
            await _actorRepo.DeleteAsync(id);
        }

        public Task<IEnumerable<ActorResponseDto>> GetActorsFromMovieId(long id)
        {
            throw new NotImplementedException();
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


        public async Task<IEnumerable<ActorResponseDto>> SearchByNameAsync(string userName)
        {
            var users = await _actorRepo.SearchByNameAsync(userName);
            var dto = _mapper.Map<IEnumerable<ActorResponseDto>>(users);
            return dto;
        }

        public async Task<ActorResponseDto> UpdateAsync(ActorRequestDto RequestDto)
        {
            var entity = _mapper.Map<Actor>(RequestDto);
            var result = await _actorRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);
        }
    }
}

