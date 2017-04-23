using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var Clientes = _context.Customers.Include(c => c.MembershipType).ToList(); // GetCustomers();


            return View(Clientes);
        }

        public ActionResult Details(int id)
        {

           var customer  = _context.Customers.Include(c => c.MembershipType).FirstOrDefault(item => item.Id == id);
            
                if (customer == null)
                    return HttpNotFound();

            return View(customer);
        }


        public ActionResult New()
        {
            var MembershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {

                MembershipTypes = MembershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer Customer)
        {

            if (Customer.Id == 0)
                _context.Customers.Add(Customer);
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == Customer.Id);

                CustomerInDb.Name = Customer.Name;
                CustomerInDb.Birthdate = Customer.Birthdate;
                CustomerInDb.MembershipTypeId = Customer.MembershipTypeId;
                CustomerInDb.IsSubscribedToNewsLetter = Customer.IsSubscribedToNewsLetter;
                
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Customers");
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer {Id = 1, Name = "Santiago Valencia"},
        //        new Customer {Id = 2, Name = "Johanna Jimenez"}
        //    };

        //}


        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            
            return View("CustomerForm", viewModel);
        }
    }
}