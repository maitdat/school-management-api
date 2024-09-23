using static NS.Core.Commons.Enums;

namespace NS.Core.Models.Entities
{
    public class KyTuyenSinh : Commons.BaseEntitySoftDeletable
    {
        public required string TenKyTuyenSinh { get; set; } // Kỳ tuyển sinh năm học 2021 - 2022
        public long NamHocId { get; set; }
        public virtual NamHoc NamHoc { get; set; }
        public int ChiTieuTuyenSinh1 { get; set; }
        public int ChiTieuTuyenSinh2 { get; set; }
        public int ChiTieuTuyenSinh3 { get; set; }
        public int ChiTieuTuyenSinh4 { get; set; }
        public int ChiTieuTuyenSinh5 { get; set; }
        public TrangThaiKyTuyenSinh TrangThaiKyTuyenSinh { get; set; }
    }
}