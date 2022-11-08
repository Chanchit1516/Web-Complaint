using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_USER : _BaseEntity
    {
        public TB_USER()
        {
            
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int BuId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        //public bool IsActive { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }

        #region
        public TB_ROLE Role { get; set; }
        public TB_BU_MASTER BU { get; set; }

        #endregion
    }
}
