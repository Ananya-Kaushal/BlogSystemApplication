using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogSystem.Models.Domain
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public required string Description { get; set; }

        //[Required]
        //[ForeignKey("Post")]
        public int PostId { get; set; }

        [Required]
        public string UserName { get; set; }

        public Guid UserId { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
