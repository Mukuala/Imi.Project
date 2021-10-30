using Imi.Project.Api.Core.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class ActorRequestDto:BaseDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IFormFile Image { get; set; }
    }
}
