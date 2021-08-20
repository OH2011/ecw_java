using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ecw.Models
{
    public partial class TmItemPrice
    {
        public string ItemCd { get; set; }
        public decimal NoTaxRetailPrice { get; set; }
        public decimal NoTaxWholesalePrice { get; set; }
        public string TaxDivCd { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }

        
    }
}
