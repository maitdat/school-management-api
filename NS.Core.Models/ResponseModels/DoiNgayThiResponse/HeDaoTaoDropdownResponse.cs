using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels;

public class HeDaoTaoDropdownResponse : BaseEntity
{
    public string HeDaoTao { get; set; }

    public static HeDaoTaoDropdownResponse Mapping(HeDaoTao model)
    {
        return new HeDaoTaoDropdownResponse()
        {
            Id = model.Id,
            HeDaoTao = model.TenHeDaoTao
        };
    }
}