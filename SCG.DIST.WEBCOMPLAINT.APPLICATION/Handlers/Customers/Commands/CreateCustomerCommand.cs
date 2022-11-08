using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Customers.Commands
{
    public class CreateCustomerCommand : IRequest
    {
        [Required]
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$")]
        public string Phone { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
