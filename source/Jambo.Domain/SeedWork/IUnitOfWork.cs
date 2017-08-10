using System;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Add(IEvent _event);
        Task SaveChanges();
    }
}
