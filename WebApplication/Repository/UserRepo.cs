using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.IRepository;
using WebApplication.Models;

namespace WebApplication.Repository
{
    public class UserRepo : GenericRepository<User>,IUserRepository
    {
        public UserRepo(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await Table.ToListAsync();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return  new List<User>();
            }
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public override async Task AddAsync(User entity)
        {
            await Table.AddAsync(entity);
            await SaveAsync();
        }

        public override async Task DeleteAsync(User entity)
        {
             Table.Remove(entity);
            await SaveAsync();
        }

        public override async Task UpdateAsync(User entity)
        {
            Table.Update(entity);
            await SaveAsync();
        }
        public override async Task SaveAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

    }

}