using Imi.Project.Wpf.Core.Entities.Base;
using System.Collections.Generic;

namespace Imi.Project.Wpf.Core.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
