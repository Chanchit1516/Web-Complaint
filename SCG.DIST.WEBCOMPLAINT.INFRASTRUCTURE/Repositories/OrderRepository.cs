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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext db) : base(db)
        { }

    }
}
