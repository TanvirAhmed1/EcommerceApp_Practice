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
                EcommerceDbContext db = new EcommerceDbContext();
                db.Customers.Add(customer);
                bool isSaved = db.SaveChanges()>0;
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }
        public IActionResult List()
        {
            EcommerceDbContext db = new EcommerceDbContext();
            List<Customer> customers = db.Customers.ToList();

            return View(customers);
        }
        public IActionResult Edit(int? id)
        {
            EcommerceDbContext db = new EcommerceDbContext();
            if (id !=null && id>0) {
                Customer existingCustomer = db.Customers.Find(id);
                if (existingCustomer != null)
                {
                    return View(existingCustomer);
                }
            }

            return View();
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            EcommerceDbContext db = new EcommerceDbContext();
            db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            if (isUpdate)
            {
                return RedirectToAction("List");
            }
            return View(customer);
        }
    }
}
