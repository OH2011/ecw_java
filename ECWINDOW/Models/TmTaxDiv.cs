using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmTaxDiv
    {
        public string TaxDivCd { get; set; }
        public decimal TaxRate { get; set; }
        public string TaxName { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
