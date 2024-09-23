using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class HoSoTrungResponseModel
    {
        public long Id { get; set; }
        public DateTime NgaySinh { get; set; }
        public long KyTuyenSinhId { get; set; }
        public long LopDangKyId { get; set; }
        public string TenHocSinh { get; set; }
        public long HeDaoTaoId { get; set; }
        public DateTime NgayDangKy { get; set; }
        public TrangThaiHoSoTuyenSinh? TrangThai { get; set; }
        public List<HoSoTrungList> HoSoTrungs { get; set; }
    }
    public class HoSoTrungList
    {
        public long Id { get; set; }
        public long LopDangKyId { get; set; }
        public long KyTuyenSinhId { get; set; }
        public long HeDaoTaoId { get; set; }
        public string TenHocSinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string HoTenBo { get; set; } = string.Empty;
        public string HoTenMe { get; set; } = string.Empty;
        public TrangThaiHoSoTuyenSinh? TrangThai { get; set; }
    }
}
