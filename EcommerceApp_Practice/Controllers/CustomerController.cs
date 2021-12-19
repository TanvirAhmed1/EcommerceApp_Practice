﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BLL;
using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Practice.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager;
        public CustomerController()
        {
            _customerManager = new CustomerManager();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            Customer customer = new Customer();
            customer.CustomerList = _customerManager.GetAll();
            return View(customer);
        }
        [HttpPost]
        public IActionResult create(Customer customer) 
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _customerManager.Add(customer);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return View();
        }
            
        public IActionResult List()
        {
            
            ICollection<Customer> customers = _customerManager.GetAll();

            return View(customers);
        }
        public IActionResult Edit(int? id)
        {
            
            if (id !=null && id>0) {
                Customer existingCustomer = _customerManager.GetById(id);
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
            bool isUpdate = _customerManager.Update(customer);
            if (isUpdate)
            {
                return RedirectToAction("List");
            }
            return View(customer);
        }
        public IActionResult Delete(int? id)
        {
            if(id!=null && id > 0)
            {
                var customer = _customerManager.GetById(id);
                bool isSaved = _customerManager.Remove(customer);
                if (isSaved)
                {
                    return RedirectToAction("List");
                }
            }
            return RedirectToAction("List");
        }
    }
}
