using SCG.DIST.WEBCOMPLAINT.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.INFRASTRUCTURE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<TB_USER> TB_USERs { get; set; }
        public virtual DbSet<TB_COMPLAINT> TB_COMPLAINTs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeederConfig.SeedConfig(modelBuilder);

        }

    }
}
