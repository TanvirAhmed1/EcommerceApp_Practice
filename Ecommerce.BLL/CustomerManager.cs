﻿using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepo;
        public CustomerManager()
        {
            _customerRepo = new CustomerRepository();
        }
        public bool Add(Customer entry)
        {
            if(entry.Name == null || entry.Name == "")
            {
                return false;
            }
            return _customerRepo.Add(entry);
        }
        public bool Update(Customer entity)
        {
            return _customerRepo.Update(entity);
        }
        public bool Remove(Customer entity)
        {
            return _customerRepo.Remove(entity);
        }
        public ICollection<Customer> GetAll()
        {
            return _customerRepo.GetAll();
        }

        public Customer GetById(int? id)
        {
            return _customerRepo.GetById(id);
        }
    }
}