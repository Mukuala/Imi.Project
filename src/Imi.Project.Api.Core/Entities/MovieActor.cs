using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class MovieActor
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey(nameof(Actor))]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

    }
}
