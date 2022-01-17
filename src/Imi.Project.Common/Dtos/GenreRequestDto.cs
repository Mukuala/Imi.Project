using Imi.Project.Common.Dtos.Base;

namespace Imi.Project.Common.Dtos
{
    public class GenreRequestDto : BaseDto<int>
    {
        public string Name { get; set; }
    }
}
