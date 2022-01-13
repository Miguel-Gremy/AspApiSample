using System;
using AspApiSample.Lib.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspApiSample.Lib
{
    public class ApplicationContext : IdentityDbContext<User, Role, Guid>
    {
        public override DbSet<User> Users { get; set; }
        public override DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}