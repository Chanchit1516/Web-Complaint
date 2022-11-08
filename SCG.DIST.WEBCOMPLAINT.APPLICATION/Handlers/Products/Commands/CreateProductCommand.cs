using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Handlers.Products.Commands
{
    public class CreateProductCommand : IRequest
    {
        [Required]
        [StringLength(2, ErrorMessage = "Name length can't be more than 2.")]
        public string ProductName { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public int UnitsOnOrder { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}
