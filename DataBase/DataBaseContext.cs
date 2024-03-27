using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using timsoft.entities;

namespace timsoft.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.EnableSensitiveDataLogging();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}

