using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class UpdateThoiGianThiRequestModel
    {
        public required long Id {  get; set; }
        public long KyTuyenSinhId { get; set; }
        public int DotThi { get; set; }
        public string NgayThi { get; set; }
        public CaThi CaThi { get; set; }
        public string GioDuThi { get; set; }
        public string GioDonCon { get; set; }
        public string GhiChu { get; set; }
    }
}
