using BlogSystem.Models.Domain;

namespace BlogSystem.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment blogPostComment);
        Task<IEnumerable<Comment>> GetCommentsByBlogIdAsync(int blogPostId);
        Task<IEnumerable<object>> GetCommentsByBlogIdAsync(Guid id);
    }
}
