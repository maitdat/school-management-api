using NS.Core.Models.Entities;
using NS.Core.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.RequestModels
{
    public class GetPagedHoSoTuyenSinhRequestModel : BasePaginationRequestModel
    {
        public long Id { get; set; }
        public long? KyTuyenSinhId { get; set; }
        public string? KhoiTuyenSinh { get; set; }
        public string? HeDaoTao { get; set; }
        public long? TaiKhoanId { get; set; }
        public string? NamHoc { get; set; }
        public KenhGioiThieu? KenhGioiThieu { get; set; }
        public TrangThaiHoSoTuyenSinh? TrangThai { get; set; }
        //public string LopDangKi { get; set; }
        public TrangThaiDanhSachDuThi TrangThaiDanhSachDuThi { get; set; }
        public DateTime NgayDangKiStart { get; set; } = DateTime.MinValue;
        public DateTime NgayDangKiEnd { get; set; } = DateTime.MinValue;
    }

}
