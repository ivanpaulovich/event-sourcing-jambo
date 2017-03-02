namespace Jambo.Core.Interfaces.Entities
{
    public interface IEntityFactory
    {
        T CriarEntity<T>();
    }
}
