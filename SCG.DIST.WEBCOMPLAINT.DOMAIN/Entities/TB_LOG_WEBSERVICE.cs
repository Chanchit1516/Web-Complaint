using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities
{
    public class TB_LOG_WEBSERVICE : _BaseEntity
    {
        public TB_LOG_WEBSERVICE()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ServiceName { get; set; }
        public string ServiceUrl { get; set; }
        public string Inbound { get; set; }
        public string Outbound { get; set; }
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
