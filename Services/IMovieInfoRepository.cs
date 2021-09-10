using System.Collections.Generic;
using api.Entities;

namespace api.Services
{
    public interface IMovieInfoRepository
    {
        IEnumerable<Movie> GetMovies();

        Movie GetMovie(int movieId, bool inclueCast);

        IEnumerable<Cast> GetCasts(int movieId);

        Cast GetCastByMovie(int movieId, int castId);
    }
}
