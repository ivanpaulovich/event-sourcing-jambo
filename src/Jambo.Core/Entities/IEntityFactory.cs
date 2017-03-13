namespace Jambo.Core.Entities
{
    public interface IEntityFactory
    {
        T Criar<T>();
    }
}
