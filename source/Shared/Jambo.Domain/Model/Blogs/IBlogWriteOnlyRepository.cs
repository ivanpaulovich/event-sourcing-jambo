namespace Jambo.Domain.Model.Blogs
{
    using System.Threading.Tasks;

    public interface IBlogWriteOnlyRepository
    {
        Task AddBlog(Blog blog);
        Task UpdateBlog(Blog blog);
    }
}
