using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.IRepository;
using WebApplication.Repository;

namespace WebApplication.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext applicationDbContext;
        public IUserRepository Users { get; private set; }
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            Users = new UserRepo(applicationDbContext);
        }

        public async Task CompleteAsync()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            applicationDbContext.Dispose();
        }
    }
}
