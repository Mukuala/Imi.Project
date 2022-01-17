using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Common.Dtos.Base
{
    public class BaseDto<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
