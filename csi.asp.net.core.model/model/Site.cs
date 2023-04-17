
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
    [Table("Site")]
    public class Site : Common
    {
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Nome da OCB")]
        public string Name  { get; set; }
    }
}
