using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId}/casts")]
    public class CastController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMovies(int movieId)
        {
            var movie = MoviesDataStore.Current
                .Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie == null)
                return NotFound();

            return Ok(movie.Casts);
        }

        [HttpGet("{id}")]
        public IActionResult GetCasts(int movieId, int id)
        {
            var movie = MoviesDataStore.Current
                .Movies.FirstOrDefault(m => m.Id == movieId);

            if (movie == null)
                return NotFound();

            var casts = movie.Casts.FirstOrDefault(c => c.Id == id);

            if (casts == null)
                return NotFound();

            return Ok(casts);
        }
    }
}
