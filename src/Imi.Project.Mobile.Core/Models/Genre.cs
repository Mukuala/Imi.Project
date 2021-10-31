using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Genre:BaseModel
    {
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

    }
}
