using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class ActorResponseDto:BaseDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IEnumerable<MovieResponseDto> Movies { get; set; }
        public string Image { get; set; }

    }
}
