using NS.Core.Commons;

namespace NS.Core.Models.Entities.LandingPage;

public class CauLacBo : BaseEntitySoftDeletable
{
    public string TenCauLacBo { get; set; }
    public string TenCauLacBoTiengAnh { get; set; }
    public string Icon { get; set; }
    public int SoBuoiHoc { get; set; }
    public int HocPhi { get; set; }
    public DateTime ThoiGianBatDau { get; set; }
    public DateTime ThoiGianKetThuc { get; set; }
    public string MoTa { get; set; }
    public string MoTaTiengAnh { get; set; }
    public virtual ICollection<AnhCauLacBo> AnhCauLacBo { get; set; }
}

