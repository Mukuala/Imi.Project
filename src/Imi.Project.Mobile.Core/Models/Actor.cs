using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Actor : BaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public string Image { get; set; }
    }
}
