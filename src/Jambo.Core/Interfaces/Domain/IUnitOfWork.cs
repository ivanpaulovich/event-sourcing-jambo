namespace Jambo.Core.Interfaces.Domain
{
    public interface IUnitOfWork
    {
        int SaveChanges();
    }
}
