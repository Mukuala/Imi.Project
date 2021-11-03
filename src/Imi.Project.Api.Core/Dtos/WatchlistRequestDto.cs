using Imi.Project.Api.Core.Dtos.Base;

namespace Imi.Project.Api.Core.Dtos
{
    public class WatchlistRequestDto : BaseDto
    {
        public long MovieId { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
