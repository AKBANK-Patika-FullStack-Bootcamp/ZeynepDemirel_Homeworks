using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class NFTBaazarDBContext : DbContext
    {
        //default constructor
        public NFTBaazarDBContext(DbContextOptions<NFTBaazarDBContext> options): base(options)
        {

        }
        //set model to tables
        public DbSet<NFTtoken> NFTtokens { get; set; }

        public DbSet<Artist> Artists { get; set; }
    }
}