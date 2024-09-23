using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class HoSoTuyenDung : Commons.BaseEntitySoftDeletable
    {
        public long TaiKhoanId { get; set; }
        public virtual TaiKhoan TaiKhoan { get; set; }
        public long ViTriTuyenDungId { get; set; }
        public virtual ViTriTuyenDung ViTriTuyenDung { get; set; }
        public string AnhHoSo { get; set; }
        public string FileCV { get; set; }
        public TrangThaiHoSoTuyenDung TrangThai { get; set; }
        public virtual ICollection<ChungChiLienQuan> ChungChiLienQuan { get; set; }
        public virtual ICollection<ViTriBoSung> ViTriBoSung { get; set; }
    }
}
