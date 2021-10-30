﻿using AutoMapper;
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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepo, IMapper mapper)
        {
            _movieRepo = movieRepo;
            _mapper = mapper;

        }

        public async Task<MovieResponseDto> AddAsync(MovieRequestDto RequestDto)
        {
            var entity = _mapper.Map<Movie>(RequestDto);

            var result = await _movieRepo.AddAsync(entity);
            var dto = _mapper.Map<MovieResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(long id)
        {
            await _movieRepo.DeleteAsync(id);
        }

        public async Task<MovieResponseDto> GetByIdAsync(long id)
        {
            var result = await _movieRepo.GetByIdAsync(id);
            var dto = _mapper.Map<MovieResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<MovieResponseDto>> GetMoviesByActorId(long id)
        {
            var result = await _movieRepo.GetByActorId(id);
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
            var result = await _movieRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);
        }
    }
}