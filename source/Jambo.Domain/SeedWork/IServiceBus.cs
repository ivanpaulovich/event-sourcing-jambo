using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IServiceBus
    {
        void Attach(IEntity entity);
        void Detach(IEntity entity);

        Task Publish();
        Task Listen();
    }
}
