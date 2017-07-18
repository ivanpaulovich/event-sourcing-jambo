namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public interface IBlogReadOnlyRepository
    {
        Blog FindAsync(int id);
    }
}
