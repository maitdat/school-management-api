using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NS.Core.Commons.Enums;

namespace NS.Core.Models.ResponseModels
{
    public class TinTucResponseModel
    {
        public long Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDungTomTat { get; set; }
        public string NoiDungChiTiet { get; set; }
        public string AnhDaiDien { get; set; }
        public string TieuDeEngLish { get; set; }
        public string NoiDungChiTietEngLish { get; set; }
        public long? ChuyenMucId { get; set; }
        public string TenChuyenMuc { get; set; }
        public string TenChuyenMucEngLish { get; set; }
        public string TacGia { get; set; }
        public DateTime NgayDang { get; set; }
        public DateTime NgayCapNhat { get; set; }
        public TrangThaiTinTuc TrangThai { get; set; }
        public bool LaTinNoiBat { get; set; }
        public bool LaTinTuc { get; set; }
        public LoaiBaiViet LoaiBaiViet {get; set;}
        public long FileAnhDaiDienId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
