using Ecommerce.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models.EntityModels
{
    public class Customer:IDeleteable
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public int? CustomerTypeId { get; set; }
        public virtual CustomerType CustomerType { get; set; }

        public bool Delete()
        {
            IsDeleted = true;
            return true;
        }
    }
}
