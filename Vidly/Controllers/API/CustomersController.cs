using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Building CRUD APIs

        // GET  /api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }


        //GET   /api/customers/1

        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }


        // POST  request will be through the URL :  api/customers
        [HttpPost]
        public Customer AddCustomers(Customer customer) // it will return the resource added which is customer
        {
            // first check the modal state , which is sent from the Request
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Add(customer);      // saved in Memory, need to save in DB
            _context.SaveChanges();

            return customer;
        }

        // PUT to fully update the object with full properties unlike PATCH  api/customers/1
        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer) // object properties in request body
        {
            // CHeck the Model state which is sent from the Request
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.NotFound);
            // first i need to catch that customer with id from DB 
            var customerDB = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // now we need to MAP  (you can use AutoMapper)
            customerDB.Name = customer.Name;
            customerDB.BirthDate = customer.BirthDate;
            customerDB.MemberShipTypeID = customer.MemberShipTypeID;
            customerDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;

            _context.SaveChanges();

            return customer;
        }

        //DELETE  request will be through   api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerDb);
            _context.SaveChanges();
        }


    }
}
