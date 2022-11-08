using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models
{
    public class MessageError : Exception
    {
        public List<string> Errors { get; set; }
        public MessageError(string messageError)
            : base(messageError)
        {

        }

        public MessageError(List<string> errors)
            : base(errors.ListToString())
        {
            Errors = errors;
        }
    }
}
