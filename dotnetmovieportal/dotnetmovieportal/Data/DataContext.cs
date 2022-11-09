using dotnetmovieportal.Dtos;
using Microsoft.EntityFrameworkCore;

namespace dotnetmovieportal.Data
{
    public class DataContext : DbContext
    {
        private const string databaseName = "movies";

        // public DataContext(DbContextOptions options) : base(options){}


      
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
            //this.Database.EnsureCreated();
        }


        public DbSet<Movie> Movies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

    // Repository Methodes
}
