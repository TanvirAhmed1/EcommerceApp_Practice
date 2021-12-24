using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ResponseModels;
using EcommerceApp_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp_Practice.AutoMapperProfiles
{
    public class EcommerceAutoMapperProfile:Profile
    {
        public EcommerceAutoMapperProfile()
        {
            CreateMap<CustomerCreateViewModel, Customer>();
            CreateMap<Customer, CustomerCreateViewModel>();
            CreateMap<Customer, CustomerResponseModel>();
        }
    }
}
