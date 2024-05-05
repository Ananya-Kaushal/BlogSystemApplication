using BlogSystem.Data;
using BlogSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogSystem.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AdminDbContext adminDbContext;

        public UserRepository(AdminDbContext adminDbContext)
        {
            this.adminDbContext = adminDbContext;
        }


        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await adminDbContext.Users.ToListAsync();

            var superAdminUser = await adminDbContext.Users
                .FirstOrDefaultAsync(x => x.Email == "superadmin@bloggie.com");

            if (superAdminUser is not null)
            {
                users.Remove(superAdminUser);
            }

            return users;
        }
    }
}
