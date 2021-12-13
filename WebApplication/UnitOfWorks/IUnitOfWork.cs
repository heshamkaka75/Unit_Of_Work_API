using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.IRepository;

namespace WebApplication.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
