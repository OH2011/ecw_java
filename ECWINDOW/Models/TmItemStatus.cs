using System;
using System.Collections.Generic;

namespace ecw.Models
{
    public partial class TmItemStatus
    {
        public string StatusCd { get; set; }
        public string StatusName { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateTime { get; set; }
        public string InsertBy { get; set; }
        public DateTime InsertTime { get; set; }
    }
}
