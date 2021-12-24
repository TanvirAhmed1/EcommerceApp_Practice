﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstractions;
using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ResponseModels;
using EcommerceApp_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApp_Practice.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerManager _customerManager;
        IMapper _mapper;
        public CustomerController(ICustomerManager customerManager, IMapper mapper)
        {
            _customerManager = customerManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            CustomerCreateViewModel customer = new CustomerCreateViewModel();
            customer.CustomerList = _customerManager.GetAll().Select(c=> _mapper.Map<CustomerResponseModel>(c)).ToList();
            return View(customer);
        }
        [HttpPost]
        public IActionResult create(CustomerCreateViewModel model) 
        {
            if (ModelState.IsValid)
            {
                Customer customer = _mapper.Map<Customer>(model);
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
