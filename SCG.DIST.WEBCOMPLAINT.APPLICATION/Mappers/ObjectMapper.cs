using AutoMapper;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers.CustomerMappers;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers.OrderMappers;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers.ProductMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Mappers
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<CustomerMapper>();
                cfg.AddProfile<OrderMapper>();
                cfg.AddProfile<ProductMapper>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
