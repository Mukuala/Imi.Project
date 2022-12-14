using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public FavoriteService(IFavoriteRepository favoriteRepo, IMapper mapper, IUserRepository userRepo)
        {
            _mapper = mapper;
            _favoriteRepo = favoriteRepo;
            _userRepo = userRepo;
        }

        public async Task<FavoriteResponseDto> AddFavoriteAsync(string userId,int movieId)
        {
            var entity = new Favorite { ApplicationUserId = userId, MovieId = movieId };

            var result = await _favoriteRepo.AddAsync(entity);
            var dto = _mapper.Map<FavoriteResponseDto>(result);
            return dto;

        }
        public async Task DeleteFavoriteAsync(string userId,int movieId)
        {
            var entity = await _favoriteRepo.GetByUserIdAndMovieIdAsync(userId, movieId);
            await _favoriteRepo.DeleteAsync(entity);
        }

        public async Task<FavoriteResponseDto> GetByUserIdAndMovieId(string userId, int movieId)
        {
            var result = await _favoriteRepo.GetByUserIdAndMovieIdAsync(userId, movieId);
            var dto = _mapper.Map<FavoriteResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<FavoriteResponseDto>> GetFavoritesByUserId(string userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            var dto = _mapper.Map<IEnumerable<FavoriteResponseDto>>(user.FavoriteMovies);
            return dto;
        }

    }
}
