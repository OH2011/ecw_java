using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmItemStock
    {
        public string ItemCd { get; set; }
        public decimal StockNum { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }

        
        
    }
}
