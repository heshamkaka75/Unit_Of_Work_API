using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.IRepository;

namespace WebApplication.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext applicationDbContext;
        protected DbSet<T> Table;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.Table = applicationDbContext.Set<T>();
        }


        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            Table.Remove(entity);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await SaveAsync();
        }
        public virtual async Task SaveAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

    }
}
