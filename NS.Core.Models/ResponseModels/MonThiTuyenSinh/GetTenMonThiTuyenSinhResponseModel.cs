using NS.Core.Commons;
using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels
{
    public class GetTenMonThiTuyenSinhResponseModel: BaseEntity
    {
        public string KyTuyenSinh { get; set; }
        public string LopDuThi { get; set; }
        public string MonThi { get; set; }
        public string HeDaoTao { get; set; }
    }
}
