using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetmovieportal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private static List<Movie> movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "Avatar", Description = "Lorem", ReleaseYear = 2009}
            };


        // GET: api/<MovieController>
        [HttpGet]
        public async Task<ActionResult<List<Movie>>> Get()
        {
          

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> Get(int id)
        {
            var movie = movies.Find(m => m.Id == id);

            if (movie == null)
            {
                return BadRequest("Movie not found.");
            }

            return Ok(movie);
        }


        // POST api/<MovieController>
        [HttpPost]
        public async Task<ActionResult<List<Movie>>> AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            return Ok(movies);  
        }

        // PUT api/<MovieController>/5
        [HttpPut]
        public async Task<ActionResult<List<Movie>>> UpdateMovie(Movie request)
        {
            var movie = movies.Find(movie => movie.Id == request.Id);

            if (movie == null)
                return BadRequest("Movie not found.");

            movie.ReleaseYear = request.ReleaseYear;
            movie.Name = request.Name;
            movie.Description = request.Description;
            
            return Ok(movies);
        }
        
        

        // DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Movie>>> Delete(int id)
        {
            var movie = movies.Find(movie => movie.Id == id);

            if (movie == null)
                return BadRequest("Movie not found.");

            movies.Remove(movie);

            return Ok(movies);
        }
    }
}
