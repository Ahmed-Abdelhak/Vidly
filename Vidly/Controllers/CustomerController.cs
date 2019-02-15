using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
                                                   
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

            return View(_context.Customers.Include(c => c.MemberShipType).ToList());   //Eager Loading
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }

        public ActionResult Add()
        {
            // here i want to pass a customer NOT Customers !  so, i won't use the above _context.Customers.Include !
            // also, the MemberShipType , so i won't be able to attach  them
            // instead, i will use a ViewModel

            var model = new AddCustomerViewModel
            {
                MemberShipTypes = _context.MemberShipTypes.ToList()      // initialize the membership types from the DB
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

            return RedirectToAction("Index", "Customer");   // returns to "Index" action in "Customer" controller

        }


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MemberShipType).SingleOrDefault(c => c.Id == id); //retrieve the Customer from the DB
            var model = new AddCustomerViewModel
            {
                MemberShipTypes = _context.MemberShipTypes.ToList(),    // initialize the Membership types from the DB
                Customer = customer
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            // instead you can use AutoMapper
           
            var customerUpdated = _context.Customers.Include(c=>c.MemberShipType).Single(c => c.Id == customer.Id);

            // i will update the fields that are shown in the Details page     // this is better than using the method UpdateOrModify (security Issues)
            customerUpdated.MemberShipTypeID = customer.MemberShipTypeID;
            if (customer.BirthDate != null)
                customerUpdated.BirthDate = customer.BirthDate;

            _context.SaveChanges();


            return RedirectToAction("Index", "Customer");
        }
    }



}