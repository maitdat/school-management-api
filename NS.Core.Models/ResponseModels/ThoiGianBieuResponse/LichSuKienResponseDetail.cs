using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;

public class LichSuKienResponseDetail:BaseEntity
{
    public DateTime NgayBatDau { get; set; }
    public DateTime NgayKetThuc { get; set; }
    public long LoaiSuKien { get; set; }
    public string LoaiSuKienTiengAnh { get; set; }
    public string TenSuKien { get; set; }
    public string TenSuKienTiengAnh { get; set; }
    public string Color { get; set; }

    public static LichSuKienResponseDetail Mapping(LichSuKien lichSuKien)
    {
        return new LichSuKienResponseDetail
        {
            Id = lichSuKien.Id,
            LoaiSuKien = lichSuKien.LoaiSuKien.Id,
            LoaiSuKienTiengAnh = lichSuKien.LoaiSuKien.LoaiSuKienTiengAnh,
            TenSuKien = lichSuKien.TenSuKien,
            TenSuKienTiengAnh = lichSuKien.TenSuKienTiengAnh,
            NgayBatDau = lichSuKien.NgayBatDau,
            NgayKetThuc = lichSuKien.NgayKetThuc,
            Color = lichSuKien.LoaiSuKien.Color,
        };
    }
}