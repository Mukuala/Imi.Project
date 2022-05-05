using Imi.Project.Common.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Common.Dtos
{
    public class ActorRequestDto : BaseDto<int>
    {
        [Required]
        public string Name { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Biography { get; set; } = "";
        public IFormFile Image { get; set; }
    }
}
