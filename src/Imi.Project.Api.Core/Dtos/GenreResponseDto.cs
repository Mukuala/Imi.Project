using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class GenreResponseDto:BaseDto
    {
        public string Name { get; set; }
        public IEnumerable<MovieResponseDto> Movies { get; set; }
    }
}
