using AutoMapper;
using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Core.Interfaces.Service;
using Imi.Project.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services
{
    public class WatchlistService : IWatchlistService
    {
        private readonly IWatchlistRepository _watchlistRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        public WatchlistService(IWatchlistRepository watchlistRepo, IMapper mapper, IUserRepository userRepo)
        {
            _mapper = mapper;
            _watchlistRepo = watchlistRepo;
            _userRepo = userRepo;
        }

        public async Task<WatchlistResponseDto> AddWatchlistAsync(WatchlistRequestDto watchlistRequestDto)
        {
            var entity = _mapper.Map<Watchlist>(watchlistRequestDto);
            var result = await _watchlistRepo.AddAsync(entity);
            var dto = _mapper.Map<WatchlistResponseDto>(result);
            return dto;
        }
        public async Task DeleteWatchlistAsync(WatchlistRequestDto watchlistRequestDto)
        {
            var entity = await _watchlistRepo.GetByUserIdAndMovieIdAsync(watchlistRequestDto.ApplicationUserId, watchlistRequestDto.MovieId);
            await _watchlistRepo.DeleteAsync(entity);
        }

        public async Task<WatchlistResponseDto> GetByIdAsync(long id)
        {
            var result = await _watchlistRepo.GetByIdAsync(id);
            var dto = _mapper.Map<WatchlistResponseDto>(result);
            return dto;
        }

        public async Task<WatchlistResponseDto> GetByUserIdAndMovieId(string userId, long movieId)
        {
            var result = await _watchlistRepo.GetByUserIdAndMovieIdAsync(userId, movieId);
            var dto = _mapper.Map<WatchlistResponseDto>(result);
            return dto;
        }

        public async Task<IEnumerable<WatchlistResponseDto>> GetWatchlistsByUserId(string userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            var dto = _mapper.Map<IEnumerable<WatchlistResponseDto>>(user.WatchlistMovies);
            return dto;
        }
    }
}
