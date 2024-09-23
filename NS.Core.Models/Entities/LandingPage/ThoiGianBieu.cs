using NS.Core.Commons;

namespace NS.Core.Models.Entities.LandingPage
{
    public class ThoiGianBieu : BaseEntitySoftDeletable
    {
        public required DateTime ThoiGianBatDau { get; set; }
        public required DateTime ThoiGianKetThuc { get; set; }
        public required string TenTiet { get; set; }
        public string TenTietTiengAnh { get; set; } = String.Empty;
        public required Enums.CaHoc CaHoc { get; set; }

        public Double ThoiLuong
        {
            get { return (ThoiGianKetThuc - ThoiGianBatDau).TotalMinutes; }
        }
    }
}