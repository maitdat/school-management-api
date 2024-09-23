using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class HoSoTuyenSinhDetailsResponseModel : HoSoTuyenSinhResponseModel
    {
        public GioiTinh GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string AnhHoSo { get; set; }
        public string AnhGiayKhaiSinh { get; set; }
        public string MaMoet { get; set; }
        public string HoKhauThuongTru { get; set; }
        public string DiaChiHienTai { get; set; }
        public string TruongDangTheoHoc { get; set; }
        public string NguoiKhaiHoSo { get; set; }
        public string AnhChiEm { get; set; }
        public string ChungChiTiengAnh { get; set; }
        public string ThanhTichKhac { get; set; }
        public string HoanCanhDacBiet { get; set; }
        public string DeNghiCuaPhuHuynh { get; set; }
        public bool ThamGiaClub { get; set; }
        public string SucKhoe { get; set; }
        public string CaTinh { get; set; }
        public string NangKhieu { get; set; }
        public string SoThich { get; set; }
    }
}

