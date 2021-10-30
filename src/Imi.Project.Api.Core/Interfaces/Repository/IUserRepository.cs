using Imi.Project.Api.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        IQueryable<ApplicationUser> GetAllAsync();
        Task<IEnumerable<ApplicationUser>> ListAllAsync();
        Task<ApplicationUser> AddAsync(ApplicationUser entity);
        Task<ApplicationUser> UpdateAsync(ApplicationUser entity);
        Task<ApplicationUser> DeleteAsync(ApplicationUser entity);
        Task<ApplicationUser> DeleteAsync(string id);
        Task<IEnumerable<ApplicationUser>> SearchByUserNameAsync(string userName);
    }
}
