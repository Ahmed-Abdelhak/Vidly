using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult Add()
        {
            // here i want to pass a customer NOT Customers !  so, i won't use the above _context.Customers.Include !
            // also, the MemberShipType , so i won't be able to attach  them
            // instead, i will use a ViewModel

            var model = new AddCustomerViewModel
            {
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Customer customer)         //Model Binding   , the request will send a form data with customer data and MVC will bind it
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges(); // this is wrapped in a SQL transaction and save the data to the DB
            }

            return RedirectToAction("Index", "Customer");

        }
    }



}