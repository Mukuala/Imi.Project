using Imi.Project.Wpf.Core.Entities.Base;

namespace Imi.Project.Wpf.Core.Entities
{
    public class MovieActor : BaseEntity
    {
        public long MovieId { get; set; }
        public Movie Movie { get; set; }

        public long ActorId { get; set; }
        public Actor Actor { get; set; }

    }
}
