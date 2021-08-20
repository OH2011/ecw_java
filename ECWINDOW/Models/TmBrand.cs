using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmBrand
    {
        public string BrandCd { get; set; }
        public string BrandName { get; set; }
        public string BrandNameKana { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
