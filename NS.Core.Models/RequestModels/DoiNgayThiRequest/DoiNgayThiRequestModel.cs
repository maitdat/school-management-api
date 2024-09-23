using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels
{
    public class DoiNgayThiRequestModel : BasePaginationRequestModel
    {
        public long KyTuyenSinhId { get; set; } = 0;
        public long HeDaoTaoId { get; set; } = 0;
        public long LopDangKyId { get; set; } = 0;
        public DateTime NgayDangKyBatDau { get; set; } = DateTime.MinValue;
        public DateTime NgayDangKyKetThuc { get; set; } = DateTime.MaxValue;
    }
}