namespace NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;

public class LichSuKienRequestModel:BasePaginationRequestModel
{
    public long? LoaiSuKien { get; set; }
    public DateTime? TuNgay { get; set; }
    public DateTime? DenNgay { get; set; }
}