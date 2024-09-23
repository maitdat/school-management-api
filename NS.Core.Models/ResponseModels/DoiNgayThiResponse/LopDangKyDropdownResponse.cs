using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels;

public class LopDangKyDropdownResponse : BaseEntity
{
    public string LopDangKy { get; set; }

    public static LopDangKyDropdownResponse Mapping(Entities.LopDuThi model)
    {
        return new LopDangKyDropdownResponse()
        {
            Id = model.Id,
            LopDangKy = model.TenLop
        };
    }
}