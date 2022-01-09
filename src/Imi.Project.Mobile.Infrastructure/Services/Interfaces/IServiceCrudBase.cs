using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IServiceCrudBase<T>
    {
        Task<T> GetByIdAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(T model);
        Task<T> CreateAsync(T model);
    }
}
