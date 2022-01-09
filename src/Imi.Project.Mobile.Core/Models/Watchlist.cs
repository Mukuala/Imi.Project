using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Models
{
    public class Watchlist : BaseModel
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
