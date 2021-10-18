using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Imi.Project.Api.Core.Entities
{
    public class MovieGenre: BaseEntity
    {
        [ForeignKey(nameof(Movie))]
        public long MovieId { get; set; }
        public Movie Movie { get; set; }

        [ForeignKey(nameof(Genre))]
        public long GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
