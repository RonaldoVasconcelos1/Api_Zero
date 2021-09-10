using System.Collections.Generic;
using System.Linq;
using api.Models;
using api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/movies")]

    public class MoviesController : ControllerBase
    {
        private IMovieInfoRepository _repository;
        private IMapper _mapper;
        public MoviesController(IMovieInfoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = _repository.GetMovies();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        [HttpGet("{id}")]
        public IActionResult GetMovies(int id, bool inclueCast)
        {
            var movie = _repository.GetMovie(id, inclueCast);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<MovieDto>(movie));
        }

    }
}
