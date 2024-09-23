using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class UngVien : Commons.BaseEntitySoftDeletable
    {
        public required string TenUngVien { get; set; }
        public required string AnhDaiDien { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChiThuongTru { get; set; }
        public string DiaChiHienTai { get; set; }
        public string TotNghiep { get; set; }
        public string ViTriUngTuyen { get; set; }

    }
}
