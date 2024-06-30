using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data
{
    public class UserManagementContext : IdentityDbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
