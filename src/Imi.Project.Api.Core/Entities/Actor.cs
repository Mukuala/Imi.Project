using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class Actor:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<MovieActor> Movies { get; set; }
        public string ImageUrl { get; set; }
    }
}
