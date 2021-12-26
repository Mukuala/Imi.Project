using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Wpf.Core.Entities
{
    public class LoggedInUser
    {
        public string JwtToken { get; set; }
    }
}
