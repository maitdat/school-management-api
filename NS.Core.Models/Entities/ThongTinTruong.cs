using NS.Core.Commons;

namespace NS.Core.Models.Entities
{
    public class ThongTinTruong : BaseEntity
    {
        public string ViTri { get; set; }
        public string TenTruong { get; set; }
        public string MoTa { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string ThoiGianLamViec { get; set; }
        public string Email { get; set; }
        public string SoDienThoaiTuyenSinh { get; set; }
        public string EmailTuyenSinh { get; set; }
        public string Facebook { get; set; }
        public string YouTube { get; set; }
    }
}
