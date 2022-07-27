using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        IPasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
        private readonly IUserRepository _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;


        public UserService(IUserRepository userRepo, IMapper mapper, UserManager<ApplicationUser> userManager, IImageService imageService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _userManager = userManager;
            _imageService = imageService;
        }

        public async Task<UserResponseDto> AddAsync(UserRequestDto userRequestDto)
        {
            var entity = _mapper.Map<ApplicationUser>(userRequestDto);
            var result = await _userManager.CreateAsync(entity, userRequestDto.Password);
            if (result.Succeeded)
            {
                var addedUser = await _userRepo.GetByIdAsync(userRequestDto.Id);
                var dto = _mapper.Map<UserResponseDto>(addedUser);
                return dto;
            }
            return null;
        }

        public async Task DeleteAsync(string id)
        {
            await _imageService.AddOrUpdateImageAsync<UserRequestDto>(null, id.ToString(), true);
            await _userRepo.DeleteAsync(id);
        }

        public async Task<UserResponseDto> GetByIdAsync(string id)
        {
            var result = await _userRepo.GetByIdAsync(id);
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
            if (!string.IsNullOrWhiteSpace(userRequestDto.Password))
            {
                passwordHasher.HashPassword(entity, userRequestDto.Password);
            }
            var user = await _userRepo.UpdateAsync(entity);
            var dto = _mapper.Map<UserResponseDto>(user);
            return dto;
        }
    }
}
