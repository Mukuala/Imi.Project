using Imi.Project.Api.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, string[] includes);
        IQueryable<T> GetAllAsync();
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteAsync(int id);
    }
}
