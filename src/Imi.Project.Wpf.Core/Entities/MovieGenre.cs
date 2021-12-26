using Imi.Project.Wpf.Core.Entities.Base;

namespace Imi.Project.Wpf.Core.Entities
{
    public class MovieGenre : BaseEntity
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }

        public long GenreId { get; set; }
        public Genre Genre { get; set; }

    }
}
