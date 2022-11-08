using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Orders
{
    public class OrderResponseDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShippedId { get; set; }
        public int CustomerId { get; set; }
    }
}
