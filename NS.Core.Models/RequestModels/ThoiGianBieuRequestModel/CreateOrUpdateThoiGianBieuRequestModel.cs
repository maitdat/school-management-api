using NS.Core.Commons;
using NS.Core.Models.Entities.LandingPage;

namespace NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;

public class CreateOrUpdateThoiGianBieuRequestModel : BaseEntity
{
    public required DateTime ThoiGianBatDau { get; set; }
    public required DateTime ThoiGianKetThuc { get; set; }
    public required string TenTiet { get; set; }
    public  string TenTietTiengAnh { get; set; } = String.Empty;
    public required Enums.CaHoc CaHoc { get; set; }

    public ThoiGianBieu Mapping()
    {
        return new ThoiGianBieu
        {
            Id = Id,
            ThoiGianBatDau = ThoiGianBatDau,
            ThoiGianKetThuc = ThoiGianKetThuc,
            TenTiet = TenTiet,
            TenTietTiengAnh = TenTietTiengAnh,
            CaHoc = CaHoc
        };
    }
}