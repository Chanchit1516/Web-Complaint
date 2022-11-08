using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Products.Queries
{
    public class GetAllProductTableQuery : IRequest<List<ProductResponseDTO>>
    {
    }
}
