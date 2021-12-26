using Imi.Project.Common.Dtos.Base;

namespace Imi.Project.Common.Dtos
{
    public class FavoriteRequestDto : BaseDto
    {
        public long MovieId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
