using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Repositories
{
    public class CustomerRepository:Repository<Customer>,ICustomerRepository
    {
        EcommerceDbContext db;
        public CustomerRepository(DbContext dbContext) : base(dbContext) 
        {
            db = (EcommerceDbContext)dbContext;
        }
        
        
        public override ICollection<Customer> GetAll()
        {
            return db.Customers.Where(c => c.IsDeleted == false).ToList();
        }
        

        public Customer GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            return GetFirstOrDefault(c=>c.Id==id);
        }
    }
}
