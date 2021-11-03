using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Api.Core.Dtos
{
    public class FavoriteRequestDto:BaseDto
    {
        public long MovieId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
