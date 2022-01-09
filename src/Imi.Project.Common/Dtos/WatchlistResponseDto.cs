using Imi.Project.Common.Dtos.Base;

namespace Imi.Project.Common.Dtos
{
    public class WatchlistResponseDto : BaseDto
    {
        public int MovieId { get; set; }
        public string ApplicationUserId { get; set; }

        public MovieResponseDto Movie { get; set; }
        public UserResponseDto User { get; set; }
    }
}
