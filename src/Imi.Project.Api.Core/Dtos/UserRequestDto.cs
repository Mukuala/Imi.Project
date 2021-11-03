using Imi.Project.Api.Core.Dtos.Base;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
namespace Imi.Project.Api.Core.Dtos
{
    public class UserRequestDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IFormFile Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
