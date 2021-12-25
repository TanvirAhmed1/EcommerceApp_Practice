using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp_Practice.Models
{
    public class CustomerEditViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public int? CustomerTypeId { get; set; }
        public ICollection<SelectListItem> CustomerTypeItems { get; set; }

    }
}
