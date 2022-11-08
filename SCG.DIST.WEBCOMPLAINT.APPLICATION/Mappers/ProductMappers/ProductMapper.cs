using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Products;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers.ProductMappers
{
    public class ProductMapper : AutoMapper.Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductResponseDTO>().ReverseMap();
        }
    }
}
