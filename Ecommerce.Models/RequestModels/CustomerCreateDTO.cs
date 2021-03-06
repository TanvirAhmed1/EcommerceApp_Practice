using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Models.RequestModels
{
    public class CustomerCreateDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Customer must have a name")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int? CustomerTypeId { get; set; }
    }
}
