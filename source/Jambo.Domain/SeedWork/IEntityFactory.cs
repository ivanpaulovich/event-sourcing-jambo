namespace Jambo.Domain.SeedWork
{
    public interface IEntityFactory
    {
        T Create<T>() where T : IEntity;
    }
}
