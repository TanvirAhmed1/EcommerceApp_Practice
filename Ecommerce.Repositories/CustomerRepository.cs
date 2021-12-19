﻿using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Repositories
{
    public class CustomerRepository
    {
        EcommerceDbContext db;
        public CustomerRepository()
        {
            db = new EcommerceDbContext();
        }
        public bool Add(Customer entity)
        {
            db.Customers.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Customer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public ICollection<Customer> GetAll()
        {
            return db.Customers.Where(c => c.IsDeleted == false).ToList();
        }
        public bool Remove(Customer customer)
        {
            customer.IsDeleted = true;
            return Update(customer);
        }

        public Customer GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return db.Customers.Find(id);
        }
    }
}
