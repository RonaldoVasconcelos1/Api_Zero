using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/movies")]

    public class MoviesController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(MoviesDataStore.Current.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovies(int id)
        {
            var movies = MoviesDataStore.Current.Movies.FirstOrDefault(m => m.Id == id);

            if (movies == null)
                return NotFound();

            return Ok(movies);
        }

    }
}
