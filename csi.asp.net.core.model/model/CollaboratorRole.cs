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
    [Table("CollaboratorRole")]
    public class CollaboratorRole : Common
    {

        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
    }
}
