using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Orders.Commands
{
    public class CreateOrderCommand : IRequest
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ShippedDate { get; set; }
        public int ShippedId { get; set; }
        [Required]
        public int CustomerId { get; set; }
    }
}
