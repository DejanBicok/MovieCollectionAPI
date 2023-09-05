global using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace MovieCollectionAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=moviesdb;User=root;Password=root;",
                new MySqlServerVersion(new Version(8, 0, 26)));
        }

        public DbSet<UserMovies> MovieCollections { get; set; }
        public DbSet<User> Users { get; set; }

    }
}