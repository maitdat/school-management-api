using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateLopDuThiRequestModel
    {
        public long GiaoVienChinhId { get; set; }
        public string TenLop { get; set; }
        public string MaLop { get; set; }
        public string ViTriPhongThi { get; set; }
    }
}
