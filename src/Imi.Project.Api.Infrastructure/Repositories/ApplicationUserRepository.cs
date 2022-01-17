using Imi.Project.Api.Core.Entities;
using Imi.Project.Api.Core.Interfaces.Repository;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imi.Project.Api.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public ApplicationUserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ApplicationUser> DeleteAsync(ApplicationUser entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<ApplicationUser> DeleteAsync(string id)
        {
            var entity = await GetByIdAsync(id);
            await DeleteAsync(entity);
            return entity;
        }

        public virtual IQueryable<ApplicationUser> GetAllAsync()
        {
            return _dbContext.ApplicationUsers
                .Include(au => au.FavoriteMovies).ThenInclude(f => f.Movie)
                .Include(au => au.WatchlistMovies).ThenInclude(w => w.Movie);
        }

        public async Task<ApplicationUser> GetByIdAsync(string id)
        {
            var et =  GetAllAsync();
             var t = await GetAllAsync().FirstOrDefaultAsync(a => a.Id.Equals(id));
            return t;
        }

        public async Task<IEnumerable<ApplicationUser>> ListAllAsync()
        {
            return await GetAllAsync().ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> SearchByUserNameAsync(string userName)
        {
            return await GetAllAsync().Where(a => a.UserName.ToLower().Contains(userName.ToLower())).ToListAsync();
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
