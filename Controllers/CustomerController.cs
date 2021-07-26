using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult create(Customer customer) 
        {
            return View();
        }
    }
}
