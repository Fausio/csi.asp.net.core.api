﻿using csi.asp.net.core.model.helper;
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
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Nome do agregado")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }
        public string? OtherFamilyOriginRef { get; set; }
        public string NeighborhoodName { get; set; }
        public string Block { get; set; }
        public string FamilyPhoneNumber { get; set; }
        public string ClosePlaceToHome { get; set; }

        #region navegations
        public virtual Partner? Partner { get; set; }

        [ForeignKey("Partner")]
        public int PartnerId { get; set; }
        //todo orgunit, see on polistation project on my git   
        public FamilyHead FamilyHead { get; set; }
        [ForeignKey("FamilyHead")]
        public int FamilyHeadId { get; set; }

        public FamilyOriginRef FamilyOriginRef { get; set; }
        [ForeignKey("FamilyOriginRefId")]
        public int FamilyOriginRefId { get; set; }
        #endregion
    }
}
