using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class HoSoTuyenSinhResponseModel
    {
        public long Id { get; set; }
        public long KyTuyenSinhId { get; set; }
        public long KhoiTuyenSinhId { get; set; }
        public string TenKhoi { get; set; }
        public string HeDaoTao { get; set; }
        public long HeDaoTaoId { get; set; }
        public long TaiKhoanId { get; set; }
        public string? TenTaiKhoan { get; set; }
        public string? MaSoHoSo { get; set; }
        public string HoTen { get; set; }
        public string NamHoc { get; set; }
        public DateTime NgayDangKy { get; set; }
        public KenhGioiThieu? KenhGioiThieu { get; set; }
        public TrangThaiHoSoTuyenSinh TrangThai { get; set; }
        public bool IsDeleted { get; set; }
        public string? SoBaoDanh { get; set; }
        public long LopDuThiId { get; set; }
        public DateTime NgayGiaoLuu { get; set; }
        public DateTime GioGiaoLuu { get; set; }
        public DateTime GioDon { get; set; }
        public TrangThaiDanhSachDuThi TrangThaiDuThi { get; set; }
        public string LopDuThi { get; set; }
        public ICollection<NguoiLienQuan>? NguoiLienQuan { get; set; }


    }
}
