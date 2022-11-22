using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Privilege> Privileges { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

    }
}
