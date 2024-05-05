using BlogSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }

        public   DbSet<Post> Posts { get; set; }
        
        public   DbSet<Comment> Comments { get; set; }
    }
}
