using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_CClAIM : _BaseEntity
    {
        public TB_CClAIM() 
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CcId { get; set; }
        public int BuId { get; set; }
        public int CId { get; set; }
        // เลขที่ข้อร้องเรียน (C-Claim)
        public string ComplaintNumber { get; set; }
        public string Step { get; set; }
        // ภาค
        public string Department { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public string Province { get; set; }
        // ชื่อสินค้า รายละเอียดผลิตภัณฑ์, Acc only
        public string AcProductNameDetail { get; set; }
        // ชื่อสินค้า ยืนยันผลิตภัณฑ์จากการสำรวจ, Acc only
        public string AcProductNameSurvey { get; set; }
        public string AcContactNumber { get; set; }
        public string AcStopTime1 { get; set; }
        public string AcStopTime2 { get; set; }
        public string AcLatestStatus { get; set; }
        public DateTime AcUpdateDate { get; set; }
        public string SvNotiName { get; set; }
        public string SvNotiStatus { get; set; }
        public string SvWorkType { get; set; }
        public string SvProject { get; set; }
        public string SvCustomerTel { get; set; }
        public string SvAddress { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime UpdatedDate { get; set; }
        //public bool IsActive { get; set; }
    }
}
