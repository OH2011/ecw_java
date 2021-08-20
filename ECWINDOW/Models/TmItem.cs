using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmItem
    {
        public string ItemCd { get; set; }
        public string ItemName1 { get; set; }
        public string ItemName2 { get; set; }
        public string ItemCategory1Cd { get; set; }
        public string ItemCategory2Cd { get; set; }
        public string BrandCd { get; set; }
        public string ModelNumber { get; set; }
        public string JanCd { get; set; }
        public string ItemImageRefDiv { get; set; }
        public string ItemImage1 { get; set; }
        public string DispFlg { get; set; }
        public string StatusCd { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
