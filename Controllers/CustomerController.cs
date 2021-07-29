using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceApp_Practice.Database;
using EcommerceApp_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Practice.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Customer customer) 
        {
            if (customer.Name!=null) {
                CustomerDbContext db = new CustomerDbContext();
                db.Customers.Add(customer);
                db.SaveChanges();
            }
            return View();
        }
    }
}
