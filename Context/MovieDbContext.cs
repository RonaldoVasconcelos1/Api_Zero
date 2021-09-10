using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        Id = 1,
                        Name = "Pandas de dedede",
                        Description = "Isosklasjsjladk"
                    },
                     new Movie
                     {
                         Id = 2,
                         Name = "Kung fu",
                         Description = "2331"
                     },
                     new Movie
                     {
                         Id = 3,
                         Name = "Karate",
                         Description = "Kid"
                     },
                     new Movie
                     {
                         Id = 4,
                         Name = "Eu tu",
                         Description = "Nos Bota Nela"
                     }
                );
            modelBuilder.Entity<Cast>()
                .HasData(
                    new Cast
                    {
                        Id = 1,
                        Name = "Daniel luis",
                        Character = "Ele memo",
                        MovieId = 1
                    },
                    new Cast
                    {
                        Id = 2,
                        Name = "Jose luis",
                        Character = "Ele memo",
                        MovieId = 2
                    },
                    new Cast
                    {
                        Id = 3,
                        Name = "Couto amem",
                        Character = "Isso",
                        MovieId = 1
                    }
                );
            base.OnModelCreating(modelBuilder);
        }

    }
}
