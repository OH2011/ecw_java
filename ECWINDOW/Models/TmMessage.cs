using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmMessage
    {
        public string MsgCd { get; set; }
        public string MsgVal { get; set; }
        public string Description { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
