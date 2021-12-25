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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceApp_Practice.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerManager _customerManager;
        ICustomerTypeManager _customerTypeManager;
        IMapper _mapper;
        public CustomerController(ICustomerManager customerManager, IMapper mapper, ICustomerTypeManager customerTypeManager)
        {
            _customerManager = customerManager;
            _mapper = mapper;
            _customerTypeManager = customerTypeManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult create()
        {
            CustomerCreateViewModel customer = new CustomerCreateViewModel();
            customer.CustomerList = _customerManager.GetAll().Select(c=> _mapper.Map<CustomerResponseModel>(c)).ToList();
            customer.CustomerTypeItems = _customerTypeManager.GetAll()
                .Select(c => new SelectListItem() {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();
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
            var model = new CustomerEditViewModel();
            model.CustomerTypeItems = _customerTypeManager.GetAll()
                .Select(c => new SelectListItem()
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

            if (id !=null && id>0) {
                Customer existingCustomer = _customerManager.GetById(id);
                if (existingCustomer != null)
                {
                    _mapper.Map<Customer, CustomerEditViewModel>(existingCustomer,model);
                }
            }
            

            return View(model);
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
