
using csi.asp.net.core.model.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace csi.asp.net.core.model.model
{
    [Table("Partner")]
    public class Partner : Common
    {
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Nome do ativista")]
        public string Name { get; set; }

        #region Navagarions
        public CollaboratorRole? CollaboratorRole { get; set; }
        public int CollaboratorRoleId { get; set; }

        public virtual Partner Superior { get; set; }
        [ForeignKey("Superior")]
        public int? PartnerId { get; set; }


        public virtual  Site Site { get; set; }
        [ForeignKey("Site")]
        public int SiteId { get; set; }

        #endregion



    }
}
