using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_MENU : _BaseEntity
    {
        public TB_MENU()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool IsSetPermission { get; set; }
        //public bool IsActive { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}
