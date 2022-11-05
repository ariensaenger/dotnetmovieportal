using dotnetmovieportal.Dtos;
using dotnetmovieportal.Models;
using dotnetmovieportal.Scripts;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetmovieportal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]  
    public class MovieController : ControllerBase
    {

        
        private readonly DataContext _context;

        public MovieController(DataContext context)
        {
            this._context = context;
        }

        // GET: api/<MovieController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<MovieDto>>> Get()
        {
            var movies = (await _context.Movies.ToListAsync()).Select(movie => movie.asDto());

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetById(Guid id)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound("Movie not found.");
            }

            return Ok(movie.asDto());
        }


        // POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<List<MovieDto>>> AddMovie([FromBody] CreateMovieDto createdMovie)
        {
            var movie = new Movie(Guid.NewGuid(), createdMovie.Name, createdMovie.Description, createdMovie.ReleaseYear);

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync(); 

            //BadRequest When Failure 

            return CreatedAtAction(nameof(GetById), new {id = movie.Id}, movie);  
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<List<MovieDto>>> UpdateMovie(Guid id,UpdateMovieDto request)
        {
            var dbexistingmovie = await _context.Movies.FindAsync(id);

            if (dbexistingmovie == null)
            {
                return NotFound("Movie not found.");
            }




            dbexistingmovie.Name = request.Name;
            dbexistingmovie.Description = request.Description;
            dbexistingmovie.ReleaseYear = request.ReleaseYear;

            


            await _context.SaveChangesAsync(); 

            return Ok((await _context.Movies.ToListAsync()).Select(movie => movie.asDto()));
        }



        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dbexistingmovie = await _context.Movies.FindAsync(id);

            if (dbexistingmovie == null)
            {
                return BadRequest("Movie not found.");
            }


            _context.Movies.Remove(dbexistingmovie);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
