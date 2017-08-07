using System;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChanges();
    }
}
