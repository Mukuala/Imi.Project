using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepo, IMapper mapper, IImageService imageService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<UserResponseDto> AddAsync(UserRequestDto userRequestDto)
        {
            var entity = _mapper.Map<ApplicationUser>(userRequestDto);
            //entity.Image = await _imageService.AddOrUpdateImageAsync<Actor>(null, null, entity, userRequestDto.Image);
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
            //if (userRequestDto.Image != null)
            //{
            //    entity.Image = await _imageService.AddOrUpdateImageAsync<ApplicationUser>(null, null, entity, userRequestDto.Image);
            //}
            //else
            //    entity.Image = _userRepo.GetByIdAsync(userRequestDto.Id).Result.Image;

            var result = await _userRepo.UpdateAsync(entity);
            return await GetByIdAsync(result.Id);

        }
    }
}
