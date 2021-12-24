using Ecommerce.Database.Database;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repositories.Abstractions;
using Ecommerce.Repositories.Abstractions.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        EcommerceDbContext _db;
        public ProductRepository(DbContext db) : base(db)
        {
            _db = (EcommerceDbContext)db;
        }

        public Product GetById(int? id)
        {
            return GetFirstOrDefault(c=>c.Id==id);
        }
    }
}
