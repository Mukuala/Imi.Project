using Imi.Project.Mobile.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<ICollection<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> DeleteAsync(string id);
        Task<ApplicationUser> UpdateAsync(ApplicationUser model);
        Task<ApplicationUser> CreateAsync(ApplicationUser model);
    }
}
