using dotnetmovieportal.Dtos;
using Microsoft.EntityFrameworkCore;

namespace dotnetmovieportal.Data
{
    public class DataContext : DbContext
    {
        private const string databaseName = "movies";

        public DataContext(DbContextOptions options) : base(options){}
        public DbSet<Movie> Movies { get; set; }    
    }

    // Repository Methodes
}
