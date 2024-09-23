using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class ThoiGianThiRequestModel
    {
        public long KyTuyenSinhId { get; set; }
        public int DotThi { get; set; }
        public Enums.CaThi CaThi { get; set; }
        public DateTime NgayThi { get; set; }
        public string GhiChu { get; set; }
    }
}
