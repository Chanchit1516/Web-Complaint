using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class _BaseEntity
    {
        public _BaseEntity()
        {
            //CreatedDateTime = DateTimeHelper.Now();
        }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
