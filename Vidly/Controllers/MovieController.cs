using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult index()
        {
            var movies = new List<Movie>
            {
              new Movie()
              {
                  Name = "shrek",
              },
                new Movie()
                {
                    Name = "Friends",
                }
            };
        
            return View(movies);
        }
    }
}