using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Mobile.Infrastructure.Services.Interfaces
{
    public interface IServiceCrudBase<T>
    {
        Task<T> GetByIdAsync(long id);
        Task<ICollection<T>> GetAllAsync();
        Task<T> DeleteAsync(long id);
        Task<T> UpdateAsync(T model);
        Task<T> CreateAsync(T model);
    }
}
