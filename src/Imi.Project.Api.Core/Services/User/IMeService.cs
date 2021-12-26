using Imi.Project.Common.Dtos;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Services.User
{
    public interface IMeService
    {
        Task<LoginResult> LoginAsync(LoginRequestDto loginCredentials);
        Task<RegisterResult> RegisterAsync(RegisterRequestDto registerModel);
        Task<UserResponseDto> GetCurrentUserProfileAsync();
    }
}
