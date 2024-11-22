using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngularNetBlogApp.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "d0d36f6b-7591-47d1-91be-71bc6c4002b0";
            var writerRoleId = "a781685b-db4b-4a2a-ad3f-fddfb384d609";

            //Create Reader and Writer role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new IdentityRole()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }
            };


            //Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);

            //Create an Admin User
            var adminUserId = "0de73c0a-bdca-43d0-a8d8-1cdc5cbb26a0";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@angularnetblogapp.com",
                Email = "admin@angularnetblogapp.com",
                NormalizedEmail = "admin@angularnetblogapp.com".ToUpper(),
                NormalizedUserName = "admin@angularnetblogapp.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);
            //Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId
                }

            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
