using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public IEnumerable<MovieGenre> Movies { get; set; }
    }
}
