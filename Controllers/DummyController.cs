using api.Context;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/teste")]
    public class DummyController : ControllerBase
    {

        private MovieDbContext _context;

        public DummyController(MovieDbContext context)
        {
            _context = context;
        }
        public IActionResult TesteDataBase()
        {
            return Ok();
        }

    }
}
