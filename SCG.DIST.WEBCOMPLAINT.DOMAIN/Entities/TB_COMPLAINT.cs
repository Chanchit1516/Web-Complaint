using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_COMPLAINT : _BaseEntity
    {
        public TB_COMPLAINT()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComId { get; set; }
        public int BuId { get; set; }
        public bool IsSurvey { get; set; }
        // ***
        public string Status { get; set; }
        // Case No. SF
        public string ComplaintNumber { get; set; }
        public DateTime OpenDate { get; set; }
        public string Goal { get; set; }
        public string CaseLevel { get; set; }
        public string ComplaintType { get; set; }
        public string Department { get; set; }
        public string CaseOwner { get; set; }
        public string Subject { get; set; }
        public string Channel { get; set; }
        public string SourceType { get; set; }
        public string Description { get; set; }
        // new system only
        public string MainIssue { get; set; }
        // new system only
        public string IsUrgent { get; set; }
        public string BpType { get; set; }
        public string AccountName { get; set; }
        // Building Code /Village/Apartment
        public string Address1 { get; set; }
        // House Number /Room
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public bool IsActive { get; set; }
    }
}
