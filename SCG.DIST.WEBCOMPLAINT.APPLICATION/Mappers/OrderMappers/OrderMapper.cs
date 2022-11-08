using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Orders;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers.OrderMappers
{
    public class OrderMapper : AutoMapper.Profile
    {
        public OrderMapper()
        {
            CreateMap<Order, OrderResponseDTO>().ReverseMap();
        }
    }
}
