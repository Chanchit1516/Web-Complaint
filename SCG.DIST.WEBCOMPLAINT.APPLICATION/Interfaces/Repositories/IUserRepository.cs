using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<TB_USER>
    {
        Task<TB_USER> GetUserByUserIDAsync(int userID);
    }
}
