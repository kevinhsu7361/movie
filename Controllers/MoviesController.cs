using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using movie.Models;
using movie.ViewModels;
using Omu.ValueInjecter;

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
            List<MovieRead> movieDetails = new List<MovieRead>();
            var movies = db.Movies.ToList();
            foreach (var movie in movies)
            {
                if (movie == null)
                {
                    return NotFound();
                }
                db.Entry(movie).Reference(m => m.Genre).Load();
                var movieDetail = (new MovieRead()).InjectFrom(movie) as MovieRead;
                movieDetail.GenreName = movie.Genre.GenreName;
                movieDetails.Add(movieDetail);
            }
            return Ok(movieDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieRead> GetMovieById(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            db.Entry(movie).Reference(m=>m.Genre).Load();
            var movieDetail = (new MovieRead()).InjectFrom(movie) as MovieRead;
            movieDetail.GenreName = movie.Genre.GenreName;
            return Ok(movieDetail);
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
            var movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return Ok();
        }
    }
}