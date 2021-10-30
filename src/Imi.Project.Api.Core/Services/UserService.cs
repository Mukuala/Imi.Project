using AutoMapper;
using Imi.Project.Api.Core.Dtos;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;

        }

        public async Task<UserResponseDto> AddAsync(UserRequestDto userRequestDto)
        {
            var entity = _mapper.Map<ApplicationUser>(userRequestDto);

            var result = await _userRepo.AddAsync(entity);
            var dto = _mapper.Map<UserResponseDto>(result);
            return dto;
        }

        public async Task DeleteAsync(string id)
        {
            await _userRepo.DeleteAsync(id);
        }

        public async Task<UserResponseDto> GetByIdAsync(string id)
        {
            var result = await _userRepo.GetAllAsync()
                .SingleOrDefaultAsync(u => u.Id.Equals(id));

            var dto = _mapper.Map<UserResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<UserResponseDto>> ListAllAsync()
        {
            var result = await _userRepo.ListAllAsync();
            var dto = _mapper.Map<IEnumerable<UserResponseDto>>(result);
            return dto;
        }

        public async Task<IEnumerable<UserResponseDto>> SearchByUserNameAsync(string userName)
        {
            var users = await _userRepo.SearchByUserNameAsync(userName);
            var dto = _mapper.Map<IEnumerable<UserResponseDto>>(users);
            return dto;
        }

        public async Task<UserResponseDto> UpdateAsync(UserRequestDto userRequestDto)
        {
            var entity = _mapper.Map<ApplicationUser>(userRequestDto);
            var result = await _userRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);

        }
    }
}
