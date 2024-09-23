using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.ResponseModels.NhanVien
{
    public class NhanVienResponseModel
    {
        public long Id { get; set; }
        public long PhongBanId { get; set; }
        public string PhongBan { get; set; }
        public string HoTen { get; set; }
        public string ChucVu { get; set; }
        public  string DanhHieu { get; set; }
        public string LinkAnh { get; set; }
        public string ThongTinLienLac { get; set; }
        public string HocVan { get; set; }
        public string QuaTrinhLamViec { get; set; }
        public bool LaChuyenVienTuVan { get; set; }
        public string ChamNgon { get; set; }
        public bool HienThi { get; set; }
        public int Hang { get; set; }
        public int Cot { get; set; }
    }
}
