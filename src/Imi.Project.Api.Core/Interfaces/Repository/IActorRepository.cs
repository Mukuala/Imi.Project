using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task<IEnumerable<Actor>> SearchByNameAsync(string name);
    }
}
