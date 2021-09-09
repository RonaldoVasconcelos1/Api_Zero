using System.Linq;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("api/movies/{movieId}/casts")]
    public class CastController : ControllerBase
    {
        private ILogger<CastController> _logger;
        private LocalMailService _mailService;
        public CastController(ILogger<CastController> logger, LocalMailService mailService)
        {

            _logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            _mailService = mailService ?? throw new System.ArgumentNullException(nameof(mailService));
        }
        [HttpGet]
        public IActionResult GetMovies(int movieId)
        {
            try
            {
                var movie = MoviesDataStore.Current
               .Movies.FirstOrDefault(m => m.Id == movieId);

                if (movie == null)
                    return NotFound();

                return Ok(movie.Casts);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Id notfound {movieId}, : {ex}");

                throw;
            }

        }

        [HttpGet("{id}", Name = "GetCasts")]
        public IActionResult GetCasts(int movieId, int id)
        {
            try
            {
                var movie = MoviesDataStore.Current
              .Movies.FirstOrDefault(m => m.Id == movieId);

                if (movie == null)
                    return NotFound();

                var casts = movie.Casts.FirstOrDefault(c => c.Id == id);

                if (casts == null)
                {
                    _logger.LogInformation($"Id notfound {id}");
                    return NotFound();
                }

                return Ok(casts);
            }
            catch (System.Exception ex)
            {
                _logger.LogCritical($"Id notfound {id}, : {ex}");

                return StatusCode(500, "Server internal error");
            }
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

        [HttpDelete("{id}")]
        public IActionResult DeleteCast(int movieId, int id)
        {
            var movie = MoviesDataStore.Current.Movies
             .FirstOrDefault(c => c.Id == movieId);

            if (movie == null)
                return NotFound();

            var castFromStore = movie.Casts.FirstOrDefault(c => c.Id == id);

            if (castFromStore == null)
                return NotFound();

            _mailService.Send("Deleted resource", $"resource from {id} is deleted");

            movie.Casts.Remove(castFromStore);

            return NoContent();
        }

    }

}
