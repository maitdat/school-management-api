using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class TinTuc : Commons.BaseEntitySoftDeletable
    {
        public string TieuDe { get; set; }
        public string NoiDungTomTat { get; set; }
        public string NoiDungChiTiet { get; set; }
        public string AnhDaiDien { get; set; }
        public long FileAnhDaiDienId { get; set; } = 0;
        public string TieuDeEnglish { get; set; }
        public string NoiDungTomTatEnglish { get; set; }
        public string NoiDungChiTietEnglish { get; set; }
        public long? ChuyenMucId { get; set; }
        public virtual ChuyenMuc ChuyenMuc { get; set; }
        public string TacGia { get; set; }
        public DateTime NgayDang { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public TrangThaiTinTuc TrangThai { get; set; }
        public LoaiBaiViet LoaiBaiViet { get; set; }
        public bool LaTinNoiBat { get; set; }
        public bool LaTinTuc { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
    }
}
