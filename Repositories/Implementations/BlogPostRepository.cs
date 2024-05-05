using BlogSystem.Data;
using BlogSystem.Models.Domain;
using BlogSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Repositories.Implementations
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogDBContext blogsDbContext;

        public BlogPostRepository(BlogDBContext blogsDbContext)
        {
            this.blogsDbContext = blogsDbContext;
        }

        public async Task<Post> AddAsync(Post post)
        {
            await blogsDbContext.AddAsync(post);
            await blogsDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeleteAsync(int id)
        {
            var existingBlog = await blogsDbContext.Posts.FindAsync(id);
            if (existingBlog != null)
            {
                blogsDbContext.Remove(existingBlog);
                await blogsDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await blogsDbContext.Posts.ToListAsync();
        }

        public async Task<Post?> GetAsync(int id)
        {
            return await blogsDbContext.Posts.FirstOrDefaultAsync(b => b.Id.Equals(id));
        }

        public async Task<Post?> UpdateAsync(Post post)
        {
            var existingBlog = await blogsDbContext.Posts
                .FirstOrDefaultAsync(x => x.Id == post.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = post.Id;
                existingBlog.Title = post.Title;
                existingBlog.Content = post.Content;
                existingBlog.BloggerName = post.BloggerName;
                existingBlog.FeaturedImageUrl = post.FeaturedImageUrl;
                existingBlog.CreatedAt = post.CreatedAt;
                existingBlog.UpdatedAt = post.UpdatedAt;

                await blogsDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }
    }
}
