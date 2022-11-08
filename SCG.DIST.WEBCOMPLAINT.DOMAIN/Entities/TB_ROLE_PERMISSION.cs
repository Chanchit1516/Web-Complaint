using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_ROLE_PERMISSION : _BaseEntity
    {
        public TB_ROLE_PERMISSION()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }
        public string PermissionName { get; set; }
        public bool Flag { get; set; }
        //public bool IsActive { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
    }
}
