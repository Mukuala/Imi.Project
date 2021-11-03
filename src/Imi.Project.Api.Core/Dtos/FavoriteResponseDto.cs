using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class FavoriteResponseDto : BaseDto
    {
        public long MovieId { get; set; }
        public string ApplicationUserId { get; set; }
        public MovieResponseDto Movie { get; set; }
        public UserResponseDto User { get; set; }
    }
}
