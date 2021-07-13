using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movie.Models;

namespace movie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext db;

        public MoviesController(MovieContext db)
        {
            this.db = db;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<Movie>> GetMovies()
        {
            return db.Movies;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            return null;
        }

        [HttpPost("")]
        public ActionResult<Movie> PostMovie(Movie model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutMovie(int id, Movie model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Movie> DeleteMovieById(int id)
        {
            return null;
        }
    }
}