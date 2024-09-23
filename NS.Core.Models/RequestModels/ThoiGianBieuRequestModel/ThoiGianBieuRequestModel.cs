using NS.Core.Commons;

namespace NS.Core.Models.RequestModels.ThoiGianBieuRequestModel;

public class ThoiGianBieuRequestModel : BasePaginationRequestModel
{
    public Enums.CaHoc CaHoc { get; set; }
    
}