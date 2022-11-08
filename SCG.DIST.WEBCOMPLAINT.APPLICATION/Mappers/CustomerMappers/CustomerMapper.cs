using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Customers;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers.CustomerMappers
{
    public class CustomerMapper : AutoMapper.Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerResponseDTO>().ReverseMap();
        }
    }
}
