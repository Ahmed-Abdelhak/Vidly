using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET  /api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>)
            );
        }

        // GET  /api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();


            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST   /api/movies
        [HttpPost]
        public IHttpActionResult AddMovie(MovieDto movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var addMovie = Mapper.Map<MovieDto, Movie>(movie);

            _context.Movies.Add(addMovie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + addMovie.Id), addMovie);
        }

        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movie)
        {
            if (!ModelState.IsValid) return BadRequest();


            var movieDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            var updatedMovie = Mapper.Map<MovieDto,Movie>(movie, movieDb);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + updatedMovie.Id), updatedMovie);

        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieDb);
            _context.SaveChanges();
        }

    }
}
