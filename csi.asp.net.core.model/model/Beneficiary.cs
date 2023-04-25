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
    [Table("Beneficiary")]
    public class Beneficiary : Common
    {
        [Column(TypeName = "varchar(50)")] 
        public string Name { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }
  
        public virtual Household? Household { get; set; }
        [ForeignKey("HouseholdId")]
        public int HouseholdId { get; set; }
    }
}
