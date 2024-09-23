namespace NS.Core.Models.Entities
{
    public class TaiKhoan : Commons.BaseEntitySoftDeletable
    {
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public string AnhDaiDien { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public DateTime NgayCapNhat { get; set; } 
        public bool IsActive { get; set; }
        public virtual ICollection<PhanQuyen> DanhSachQuyen { get; set; }
    }
}
