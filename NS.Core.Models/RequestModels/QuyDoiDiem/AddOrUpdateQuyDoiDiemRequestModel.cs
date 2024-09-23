using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class AddOrUpdateQuyDoiDiemRequestModel
    {
        public long MonThiTuyenSinhId { get; set; }
        public int DiemBatDau { get; set; }
        public int DiemKetThuc { get; set; }
        public string KetQua { get; set; }
    }
}
