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
    [Table("Household")]
    public class Household : Common
    {

        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Nome do agregado")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string? OtherFamilyOriginRef { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string NeighborhoodName { get; set; }

        [Column(TypeName = "varchar(5)")]
        public string Block { get; set; }

        [Column(TypeName = "varchar(9)")]
        public string FamilyPhoneNumber { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ClosePlaceToHome { get; set; }

        #region navegations
        public virtual Partner? Partner { get; set; }

        [ForeignKey("Partner")]
        public int PartnerId { get; set; }
        //todo orgunit, see on polistation project on my git   
        public virtual FamilyHead FamilyHead { get; set; }
        [ForeignKey("FamilyHead")]
        public int FamilyHeadId { get; set; }

        public virtual FamilyOriginRef FamilyOriginRef { get; set; }
        [ForeignKey("FamilyOriginRefId")]
        public int FamilyOriginRefId { get; set; }
        #endregion
    }
}
