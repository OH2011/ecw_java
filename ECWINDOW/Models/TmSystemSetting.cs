using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmSystemSetting
    {
        public string SsId { get; set; }
        public string SsCd { get; set; }
        public string SsName { get; set; }
        public string SsVal { get; set; }
        public string Description { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
