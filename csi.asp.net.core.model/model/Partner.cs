
using csi.asp.net.core.model.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.model.model
{
    public class Partner : Common
    {
        public string Name { get; set; }

        #region Navagarions
        public CollaboratorRole? CollaboratorRole { get; set; }
        public int CollaboratorRoleId { get; set; }

        public Partner Superior { get; set; }
        public int PartnerId { get; set; }


        public Site Site { get; set; }
        public int SiteId { get; set; }

        #endregion



    }
}
