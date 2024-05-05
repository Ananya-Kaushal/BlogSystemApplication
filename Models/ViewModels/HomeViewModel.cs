using BlogSystem.Models.Domain;

namespace BlogSystem.Models.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Post> BlogPosts { get; set; }
    }
}
