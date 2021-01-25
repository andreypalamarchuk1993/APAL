using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.EF
{
    public class ApplicationContext : DbContext
    {
        private string _connectionString;

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationContext(string connectionString)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
