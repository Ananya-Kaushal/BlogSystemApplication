using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models.Domain
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Content { get; set; }
        public string? ShortDescription { get; set; }
        public required string FeaturedImageUrl { get; set; }

        public required string BloggerName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public ICollection<Comment>? Comments { get; set; }

    }
}
