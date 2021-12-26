using Imi.Project.Common.Dtos.Base;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class GenreResponseDto : BaseDto
    {
        public string Name { get; set; }
        public IEnumerable<MovieResponseDto> Movies { get; set; }
    }
}
