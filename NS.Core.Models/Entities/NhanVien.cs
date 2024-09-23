using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class NhanVien : Commons.BaseEntitySoftDeletable
    {
        public long PhongBanId { get; set; }
        public virtual PhongBan PhongBan { get; set; }
        public  string HoTen { get; set; }
        public  string ChucVu { get; set; }
        public  string DanhHieu { get; set; }
        public string LinkAnh { get; set; }
        public long? FileId { get; set; }
        public FileUpload File { get; set; }
        public string ThongTinLienLac { get; set; }
        public string HocVan { get; set; }
        public string QuaTrinhLamViec { get; set; }
        public string ChamNgon { get; set; }
        public bool HienThi { get; set; } = true;
        public bool LaChuyenVienTuVan { get; set; }
        public int Hang { get; set; }
        public int Cot { get; set; }
    }
}
