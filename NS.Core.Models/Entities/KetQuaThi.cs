using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models.Entities
{
    public class KetQuaThi : Commons.BaseEntity
    {
        public long MonThiTuyenSinhId { get; set; }
        public virtual MonThiTuyenSinh MonThiTuyenSinh { get; set; }
        public long HoSoThiId { get; set; }
        public virtual HoSoThi HoSoThi { get; set; }
        public long TieuChiDanhGiaId { get; set; }
        public virtual TieuChiDanhGia TieuChiDanhGia { get; set; }
        public long ThanhVienHoiDongId { get; set; }
        public virtual ThanhVienHoiDong ThanhVienHoiDong { get; set; }
        public int Diem { get; set; }
        public string QuyDoi { get; set; }
        public string NhanXet { get; set; }
    }
}
