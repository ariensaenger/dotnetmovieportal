using Microsoft.EntityFrameworkCore;

namespace dotnetmovieportal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}
        public DbSet<Movie> Movies { get; set; }    
    }
}
