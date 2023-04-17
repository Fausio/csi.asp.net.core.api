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
        public DbSet<HouseHold>  houseHolds { get; set; }
       
    }
}
