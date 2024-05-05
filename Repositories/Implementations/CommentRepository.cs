using BlogSystem.Data;
using BlogSystem.Models.Domain;
using BlogSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Repositories.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDBContext dbContext;

        public CommentRepository(BlogDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Comment> AddAsync(Comment blogPostComment)
        {
            await dbContext.Comments.AddAsync(blogPostComment);
            await dbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByBlogIdAsync(int blogPostId)
        {
            return await dbContext.Comments.Where(x => x.PostId == blogPostId)
                .ToListAsync();
        }

        public Task<IEnumerable<object>> GetCommentsByBlogIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
