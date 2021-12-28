using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.AutomapperProfile
{
    public class EcommerceApiAutomapperProfile:Profile
    {
        public EcommerceApiAutomapperProfile()
        {
            CreateMap<CustomerCreateDTO, Customer>();
        }
        
    }
}
