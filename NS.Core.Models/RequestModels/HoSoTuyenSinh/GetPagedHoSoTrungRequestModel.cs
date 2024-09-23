using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedHoSoTrungRequestModel:BasePaginationRequestModel
    {
        public long? HeDaoTaoId { get; set; }
        public TrangThaiHoSoTuyenSinh? TrangThai { get; set; }
        public long KyTuyenSinhId { get; set; }
        public long? LopDangKyId { get; set; }
        public DateTime NgayDangKiBatDau { get; set; } = DateTime.MinValue;
        public DateTime NgayBangKiKetThuc { get; set; } = DateTime.MinValue;
      
    }
}
