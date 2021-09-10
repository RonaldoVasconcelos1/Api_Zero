using System.Collections.Generic;
using System.Linq;
using api.Context;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class MovieInfoRepository : IMovieInfoRepository
    {
        private readonly MovieDbContext _context;
        public MovieInfoRepository(MovieDbContext context)
        {
            _context = context;
        }
        public Cast GetCastByMovie(int movieId, int castId)
        {
            return _context.Casts
                .Where(m => m.Id == movieId && m.Id == castId)
                .FirstOrDefault();
        }

        public IEnumerable<Cast> GetCasts(int movieId)
        {
            return _context.Casts
                .Where(c => c.Id == movieId).ToList();
        }

        public Movie GetMovie(int movieId, bool inclueCast)
        {
            if (inclueCast)
            {
                return _context.Movies.Include(c => c.Casts)
                    .Where(c => c.Id == movieId)
                    .FirstOrDefault();
            }
            return _context.Movies.Where(m => m.Id == movieId).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.OrderBy(m => m.Name).ToList();
        }
    }
}
