using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters")]
        public required string Password { get; set; }
    }
}
