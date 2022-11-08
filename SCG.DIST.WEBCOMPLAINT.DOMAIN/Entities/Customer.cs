using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class Customer : _BaseEntity
    {
        public Customer()
        {
            Order = new List<Order>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactTitle { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Order> Order { get; }
    }
}
