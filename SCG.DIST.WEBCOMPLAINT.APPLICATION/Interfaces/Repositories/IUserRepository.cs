using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories
{
    public interface IComplaintRepository : IGenericRepository<TB_COMPLAINT>
    {
        Task<TB_COMPLAINT> GetComplaintByCaseNoAsync(string caseNo);
    }
}
