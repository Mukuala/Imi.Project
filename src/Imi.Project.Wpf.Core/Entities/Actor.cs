using Imi.Project.Wpf.Core.Entities.Base;
using System;
using System.Collections.Generic;

namespace Imi.Project.Wpf.Core.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Biography { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public string Image { get; set; }
    }
}
