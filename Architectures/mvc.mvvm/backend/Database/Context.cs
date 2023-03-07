using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Db");
        }

        public DbSet<User> Users { get; set; }    
    }
}