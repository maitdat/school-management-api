using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class CreateOrUpdateHoiDongKhaoThiModel
    {
        public long KyTuyenSinhId { get; set; }
        public string TenHoiDong { get; set; }
    }
}
