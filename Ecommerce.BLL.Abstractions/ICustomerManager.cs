using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Abstractions
{
    public interface ICustomerManager
    {
        bool Add(Customer entity);
        bool Update(Customer entity);
        bool Remove(Customer entity);
        ICollection<Customer> GetAll();
        Customer GetById(int? id);
        ICollection<Customer> GetByRequest(CustomerRequestModel customer);
    }
}
