using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class NFTBaazarDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        //default constructor
        public NFTBaazarDBContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost; Database = NFTBaazar; integrated security = True;");
        }

        //set model to tables
        public DbSet<NFTtoken> NFTtokens { get; set; }

        public DbSet<Artist> Artists { get; set; }

        //public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().ToTable("Artists");
            modelBuilder.Entity<NFTtoken>().ToTable("NFTtokens");
        }
    }
}