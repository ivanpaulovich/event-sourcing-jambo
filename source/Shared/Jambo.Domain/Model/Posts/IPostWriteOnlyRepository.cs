namespace Jambo.Domain.Model.Posts
{
    using System.Threading.Tasks;

    public interface IPostWriteOnlyRepository
    {
        Task AddPost(Post post);
        Task UpdatePost(Post post);
    }
}
