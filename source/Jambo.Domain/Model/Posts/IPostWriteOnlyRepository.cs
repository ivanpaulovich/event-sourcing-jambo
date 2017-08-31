using System.Threading.Tasks;

namespace Jambo.Domain.Model.Posts
{
    public interface IPostWriteOnlyRepository
    {
        Task AddPost(Post post);
        Task UpdatePost(Post post);
    }
}
