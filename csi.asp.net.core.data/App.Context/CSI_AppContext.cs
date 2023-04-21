using csi.asp.net.core.model.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.data.App.Context
{
    public class CSI_AppContext  : DbContext  
    {

        public DbSet<Site> sites { get; set; }
        public DbSet<CollaboratorRole>  collaboratorRoles { get; set; }
        public DbSet<Partner>  partners { get; set; }
        public DbSet<Household>  houseHolds { get; set; }

        public DbSet<FamilyHead>  familyHeads { get; set; }

        public DbSet<FamilyOriginRef>  familyOriginRefs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Initial Catalog=csi_demo;Persist Security Info=False;User=sa;Password=0l0ga;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }
}
