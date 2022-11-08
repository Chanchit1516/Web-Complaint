using SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Customers;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Customers.Queries
{
    public class GetAllCustomerTableQuery : IRequest<List<CustomerResponseDTO>>
    {

    }
}
