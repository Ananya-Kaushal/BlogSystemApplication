using Microsoft.AspNetCore.Identity;

namespace BlogSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
