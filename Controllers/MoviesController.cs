using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            // 只會 inject 到相對應的欄位。
            //var customers = db.Customers.Include(c=>c.MemberShip).Select(c => (new CustomerRead()).InjectFrom(c) as CustomerRead);
            var movies = db.Movies;
            var customerDetails = (new MovieRead()).InjectFrom(movies) as MovieRead;
            //customerDetails.MemberShipName
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                return NotFound();
            }
            var movieDetail = (new MovieRead()).InjectFrom(movie) as MovieRead;
            //customerDetail.MemberShipName = customer.MemberShip.MemberShipName;
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
            return null;
        }
    }
}