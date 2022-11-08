using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.DTOs.Products
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public string Barcode { get; set; }
        public int OrderId { get; set; }
    }
}
