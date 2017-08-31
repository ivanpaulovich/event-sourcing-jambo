using System.Threading.Tasks;

namespace Jambo.Domain.Model.Blogs
{
    public interface IBlogWriteOnlyRepository
    {
        Task AddBlog(Blog blog);
        Task UpdateBlog(Blog blog);
    }
}
