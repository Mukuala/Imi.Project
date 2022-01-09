using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class MovieGenre
    {
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
