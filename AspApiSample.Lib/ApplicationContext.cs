using System;
using System.Collections.Generic;
using AspApiSample.Lib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspApiSample.Lib
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public override DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var seedUser = new List<User>
            {
                new User
                {
                    Id= 1,
                    FirstName= "admin",
                    LastName= "admin",
                    UserName= "admin@admin.admin",
                    NormalizedUserName= "ADMIN@ADMIN.ADMIN",
                    Email= "admin@admin.admin",
                    NormalizedEmail= "ADMIN@ADMIN.ADMIN",
                    EmailConfirmed= true,
                    PasswordHash= "AQAAAAEAACcQAAAAEHoNSf7cPXI/GnfyLcqQBuNXhMCbPYb2Ocw4TBtBsS6xg6vCcK5ZUnFrj/TX/gmJHw==",
                    SecurityStamp= "RZDI2Q4WBMHCJTA5LYEVQBJH5CC4RTRX",
                    PhoneNumberConfirmed= false,
                    TwoFactorEnabled = false,
                    LockoutEnabled= true,
                    AccessFailedCount= 0,
                }
            };
            var seedRole = new List<IdentityRole<long>>
            {
                new IdentityRole<long>
                {
                    Id = 1,
                    Name = "user",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "c992e1d8-1c5e-452a-8eaf-838bca6eac51"
                },
                new IdentityRole<long>
                {
                    Id = 2,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "c992e1d8-1c5e-452a-8eaf-838bca6eac51"
                }
            };
            var seedUserRole = new List<IdentityUserRole<long>>
            {
                new IdentityUserRole<long>
                {
                    RoleId = 1,
                    UserId = 1
                },
                new IdentityUserRole<long>
                {
                    RoleId = 2,
                    UserId = 1
                }
            };

            builder.Entity<User>().HasData(seedUser);
            builder.Entity<IdentityRole<long>>().HasData(seedRole);
            builder.Entity<IdentityUserRole<long>>().HasData(seedUserRole);
        }
    }
}