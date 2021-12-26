using Imi.Project.Common.Dtos.Base;
using System;
using System.Collections.Generic;

namespace Imi.Project.Common.Dtos
{
    public class ActorResponseDto : BaseDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IEnumerable<MovieResponseDto> Movies { get; set; }
        public string Image { get; set; }

    }
}
