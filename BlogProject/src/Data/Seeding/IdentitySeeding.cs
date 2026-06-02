using BlogProject.Core.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Data.Seeding
{
    public class IdentitySeeding
    {
        public async Task SeedingAsync(BlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var seedingAdminRoleId = Guid.NewGuid();

            if (!context.Roles.Any())
            {
                var seedingAdminRole = new AppRole
                {
                    Id = seedingAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Administrator",
                };
                await context.Roles.AddAsync(seedingAdminRole);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var seedingAdminUser = new AppUser
                {
                    Id = Guid.NewGuid(),
                    UserName = "kai_nguyen",
                    NormalizedUserName = "KAI_NGUYEN",
                    Email = "trungnguyen1221999@gmail.com",
                    NormalizedEmail = "TRUNGNGUYEN1221999@GMAIL.COM",
                    FirstName = "Kai",
                    LastName = "Nguyen",
                    IsActive = true,
                    DateCreated = DateTime.UtcNow,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                };
                seedingAdminUser.PasswordHash = passwordHasher.HashPassword(
                    seedingAdminUser,
                    "123456"
                );
                await context.Users.AddAsync(seedingAdminUser);
                await context.UserRoles.AddAsync(
                    new IdentityUserRole<Guid>
                    {
                        RoleId = seedingAdminRoleId,
                        UserId = seedingAdminUser.Id,
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
