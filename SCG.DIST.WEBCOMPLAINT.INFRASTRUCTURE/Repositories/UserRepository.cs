using Microsoft.EntityFrameworkCore;
using SCG.DIST.WEBCOMPLAINT.APPLICATION.Interfaces.Repositories;
using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Repositories
{
    public class UserRepository : GenericRepository<TB_USER>, IUserRepository
    {
        public UserRepository(ApplicationDbContext db) : base(db)
        {

        }

        public async Task<TB_USER> GetUserByUserIDAsync(int userID)
        {
            return await _dbContext.TB_USERs.FirstOrDefaultAsync(w => w.UserId == userID);
        }
    }

    //public interface IUserRepository : IGenericRepository<TB_USER>
    //{
    //    Task<TB_USER> GetUserByUserIDAsync(int userID);
    //}
}
