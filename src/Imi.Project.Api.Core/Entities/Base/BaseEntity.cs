using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Imi.Project.Api.Core.Entities.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
