using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing) // just for best practices 
        {
            base.Dispose(disposing);
            _context.Dispose();
        }


        // GET: Movie
        public ActionResult Index()
        {

            return View(_context.Movies.Include(m => m.Genre).ToList()); // Eager loading "Include Genres"
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }

        public ActionResult Add()
        {

            var addedMoviewModel = new AddMoviewViewModel
            {
                Genre = _context.Genres.ToList()
            };

            return View(addedMoviewModel);
        }

        [HttpPost]
        public ActionResult Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
            }
            else
            {
                var addedMoviewModel = new AddMoviewViewModel
                {
                    Genre = _context.Genres.ToList()
                };

                return View(addedMoviewModel);
            }

            return RedirectToAction("Index", "Movie");

        }
    }
}