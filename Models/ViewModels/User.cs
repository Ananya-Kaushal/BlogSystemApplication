using BlogSystem.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Models.ViewModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}
