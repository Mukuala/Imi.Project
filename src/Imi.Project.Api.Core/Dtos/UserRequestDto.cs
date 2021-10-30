using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;
namespace Imi.Project.Api.Core.Dtos
{
    public class UserRequestDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
