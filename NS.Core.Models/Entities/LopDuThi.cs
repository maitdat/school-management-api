namespace NS.Core.Models.Entities
{
    public class LopDuThi : Commons.BaseEntitySoftDeletable
    {
        public virtual ICollection<GiaoVienTrongThi> GiaoVienTrongThi { get; set; }
        public long ThoiGianThiId { get; set; }
        public virtual ThoiGianThi ThoiGianThi { get; set; }
        public virtual ICollection<MonThiTuyenSinh> MonThiTuyenSinhs { get; set; }
        public int SoLuong { get; set; }
        public int ConTrong { get; set; }
        public string TenLop { get; set; } //Nhom thi
        public string MaLop { get; set; }
        public string ViTriPhongThi { get; set; }
    }
}