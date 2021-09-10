using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }
}
