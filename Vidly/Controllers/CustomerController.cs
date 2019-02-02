using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {

            return View(_context.Customers.Include(c => c.MemberShipType).ToList());
        }

        public ActionResult Details(int id)
        {
            var emp = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            return View(emp);
        }

    }



}