﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.RequestModels.NhanVien
{
    public class NhanVienRequestModel
    {
        public long PhongBanId { get; set; }
        public required string HoTen { get; set; }
        public required string ChucVu { get; set; }
        public string LinkAnh { get; set; }
        public string ThongTinLienLac { get; set; }
        public string HocVan { get; set; }
        public string QuaTrinhLamViec { get; set; }
        public string ChamNgon { get; set; }
        public bool HienThi { get; set; } = true;
    }
}
