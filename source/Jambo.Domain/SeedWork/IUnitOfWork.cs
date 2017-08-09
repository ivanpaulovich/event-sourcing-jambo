using System;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Add(IEvent _event);
        Task SaveChanges();
    }
}
