using System.Linq;
using api.Models;
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

        [HttpGet("{id}", Name = "GetCasts")]
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


        [HttpPost]

        public IActionResult CreateCast(int movieId, [FromBody] CastForCreateDto cast)
        {
            var movie = MoviesDataStore.Current.Movies
                .FirstOrDefault(m => m.Id == movieId);

            if (movie == null)
                return NotFound();

            var maxCastId = MoviesDataStore.Current.Movies
                .SelectMany(x => x.Casts)
                .Max(p => p.Id);

            var newCast = new CastDto
            {
                Id = ++maxCastId,
                Name = cast.Name,
                Character = cast.Character,
            };

            movie.Casts.Add(newCast);

            return CreatedAtRoute(
                nameof(GetCasts),
                new { movieId = movieId, id = newCast.Id },
                cast
            );
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCast(int movieId, int id, [FromBody] CastForUpdateDto cast)
        {

            var movie = MoviesDataStore.Current.Movies
                .FirstOrDefault(c => c.Id == movieId);

            if (movie == null)
                return NotFound();

            var castFromStore = movie.Casts.FirstOrDefault(c => c.Id == id);

            if (castFromStore == null)
                return NotFound();

            castFromStore.Name = cast.Name;
            castFromStore.Character = cast.Character;
            return NoContent();
        }



    }

}
