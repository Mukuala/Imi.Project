using Imi.Project.Common.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;

namespace Imi.Project.Common.Dtos
{
    public class ActorRequestDto : BaseDto<int>
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IFormFile Image { get; set; }
    }
}
