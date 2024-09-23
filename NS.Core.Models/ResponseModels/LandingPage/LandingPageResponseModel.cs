using NS.Core.Commons;
using NS.Core.Models.Entities;

namespace NS.Core.Models.ResponseModels.LandingPage
{
    public class LandingPageResponseModel : BaseEntity
    {
        public string TenTrang { get; set; }
        public ICollection<CaiDatTongThe> CaiDatTongThe { get; set; }
        public static LandingPageResponseModel Mapping(Trang trang)
        {
            return new LandingPageResponseModel
            {
                TenTrang = trang.TenTrang,
                Id = trang.Id,
                CaiDatTongThe = trang.CaiDatTongThe
            };
        }
    }
}
