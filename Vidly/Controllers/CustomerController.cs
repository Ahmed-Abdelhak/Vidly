using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {

        List<Customer> _customers = new List<Customer>
        {
            new Customer()
            {
                Name = "Ahmed",
                  Id = 1
            },
            new Customer()
            {
                Name = "Mohamed"  ,
                Id = 2
            }

        };
        public ActionResult Index()
        {
           
            return View(_customers);
        }

        public ActionResult Details(int id)
        {
            var emp = _customers.Find(e=>e.Id == id);
            return View(emp) ;
        }

       
    }
}