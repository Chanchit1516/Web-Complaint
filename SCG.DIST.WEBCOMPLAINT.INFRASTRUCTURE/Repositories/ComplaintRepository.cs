using Microsoft.EntityFrameworkCore;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Repositories
{
    public class ComplaintRepository : GenericRepository<TB_COMPLAINT>, IComplaintRepository
    {
        public ComplaintRepository(ApplicationDbContext db) : base(db)
        {

        }


        public async Task<TB_COMPLAINT> GetComplaintByCaseNoAsync(string caseNo)
        {
            return await _dbContext.TB_COMPLAINTs.FirstOrDefaultAsync(w => w.ComplaintNumber == caseNo);
        }


    }

}
