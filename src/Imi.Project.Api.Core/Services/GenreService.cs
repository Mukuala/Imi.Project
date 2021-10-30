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
    public class GenreService : IService<GenreResponseDto, GenreRequestDto>
    {
        private readonly IRepository<Genre> _genreRepo;
        private readonly IMapper _mapper;
        public GenreService(IRepository<Genre>genreRepo,IMapper mapper)
        {
            _genreRepo = genreRepo;
            _mapper = mapper;
        }


        public async Task<GenreResponseDto> AddAsync(GenreRequestDto RequestDto)
        {
            var entity = _mapper.Map<Genre>(RequestDto);
            var result = await _genreRepo.AddAsync(entity);
            var dto = _mapper.Map<GenreResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(long id)
        {
            await _genreRepo.DeleteAsync(id);
        }

        public async Task<GenreResponseDto> GetByIdAsync(long id)
        {
            var result = await _genreRepo.GetByIdAsync(id);
            var dto = _mapper.Map<GenreResponseDto>(result);
            return dto;

        }

        public async Task<IEnumerable<GenreResponseDto>> ListAllAsync()
        {
            var result = await _genreRepo.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<GenreResponseDto>>(result);
            return dto;
        }

        public async Task<GenreResponseDto> UpdateAsync(GenreRequestDto RequestDto)
        {
            var entity = _mapper.Map<Genre>(RequestDto);
            var result = await _genreRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);
        }
    }
}