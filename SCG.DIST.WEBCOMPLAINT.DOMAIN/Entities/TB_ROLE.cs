using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_ROLE : _BaseEntity
    {
        public TB_ROLE()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
       
    }
}
