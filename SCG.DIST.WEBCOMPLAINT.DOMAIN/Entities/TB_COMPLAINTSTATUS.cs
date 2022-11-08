using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_COMPLAINTSTATUS : _BaseEntity
    {
        public TB_COMPLAINTSTATUS()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CsId { get; set; }
        public int ComId { get; set; }
        public int Order { get; set; }
        // เเยกด้วยสิ่งนี้
        public string Status { get; set; }
        public DateTime PlanDate { get; set; }
        public DateTime ActualDate { get; set; }
        // Overdue / On Time
        public string ActualPlan { get; set; }
        public string Text { get; set; }
        // Resolve only
        public string WorkInProgress { get; set; }
       
    }
}
