using csi.asp.net.core.model.helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.model.model
{
    [Table("FamilyOriginRef")]
    public class FamilyOriginRef : Common
    {
        public string Description { get; set; }
    }
}
