using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TtOrderHistory
    {
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public int RecordNo { get; set; }
        public string ItemCd { get; set; }
        public decimal OrderQuantity { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
