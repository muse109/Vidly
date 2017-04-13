using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
       

        // GET: Customers
        public ActionResult Index()
        {
            var Clientes = GetCustomers();


            return View(Clientes);
        }

        public ActionResult Details(int? id)
        {

            var Clientes = GetCustomers();
            Customer Cliente = null ;

            if (id != null)
            {

                Cliente = Clientes.FirstOrDefault(item => item.Id == id);


                if (Cliente == null)
                    return HttpNotFound();


            }
            



            return View(Cliente);
        }



        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Santiago Valencia"},
                new Customer {Id = 2, Name = "Johanna Jimenez"}
            };

        }


    }
}